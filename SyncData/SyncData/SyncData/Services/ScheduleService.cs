using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using log4net;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using SyncData.Models.CjDropShippingModels;
using SyncData.Models.WooCommerceModels;
using SyncData.Services.Repository;

namespace SyncData.Services
{
    public static class ScheduleService
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ScheduleService));
        private static readonly IProductRepository ProductRepository = new ProductRepository();
        private static readonly object WooCommerceLock = new object();
        private static readonly object CjShoppingLock = new object();


        public static void WooCommerceSchedule()
        {
            lock (WooCommerceLock)
            {
                try
                {
                    var pageNumber = 1;
                    var canExecute = true;
                    var wooCommerceClient = new RestClient(ConfigurationManager.AppSettings.Get("WooCommerceUrl"));
                    var wooCommerceSecret = ConfigurationManager.AppSettings.Get("WooCommerceSecret");
                    var wooCommerceKey = ConfigurationManager.AppSettings.Get("WooCommerceKey");
                    while (canExecute)
                    {
                        var request = new RestRequest("wp-json/wc/v3/Products", Method.GET);
                        request.AddParameter("consumer_key", wooCommerceKey);
                        request.AddParameter("consumer_secret", wooCommerceSecret);
                        request.AddParameter("page", pageNumber.ToString());
                        var response = wooCommerceClient.Execute<List<Product>>(request);
                        //10 is default number of products
                        if (response.Data.Count < 10)
                            canExecute = false;

                        if (response.Data == null)
                        {
                            Logger.Error(
                                $"{nameof(WooCommerceSchedule)}: Products not found against PageNumber:{pageNumber}");
                            return;
                        }

                        foreach (var wooCommerceProduct in response.Data)
                            if (!wooCommerceProduct.Variations.Any())
                                ProductRepository.AddProductSku(wooCommerceProduct.Sku, wooCommerceProduct.Id);
                            else
                                foreach (var productId in wooCommerceProduct.Variations)
                                {
                                    var product = GetProductById(productId, wooCommerceClient, wooCommerceKey,
                                        wooCommerceSecret);
                                    if (product != null)
                                        ProductRepository.AddProductSku(product.Sku, productId);
                                    else
                                        Logger.Error(
                                            $"{nameof(WooCommerceSchedule)}: Product not found against ProductId:{productId}");
                                }

                        pageNumber++;
                    }
                }
                catch (Exception e)
                {
                    Logger.Error($"{nameof(WooCommerceSchedule)}: Failed due to {e.Message}.");
                }
            }
        }

        public static void CjDropShippingSchedule()
        {
            lock (CjShoppingLock)
            {
                try
                {
                    var cjShoppingClient = new RestClient(ConfigurationManager.AppSettings.Get("CjAccessUrl"));
                    var cjShoppingSecret = ConfigurationManager.AppSettings.Get("CjAccessToken");
                    var allProducts = ProductRepository.GetAllProducts();
                    foreach (var product in allProducts)
                        if (!string.IsNullOrWhiteSpace(product.Sku))
                        {
                            var requestBody = new CjRequestBody
                            {
                                sku = product.Sku
                            };
                            var request = new RestRequest("api/product/connectList", Method.POST);
                            request.AddHeader("Content-Type", "application/json");
                            request.AddHeader("CJ-Access-Token", cjShoppingSecret);
                            request.AddJsonBody(JsonConvert.SerializeObject(requestBody));
                            var response = cjShoppingClient.Execute<CjResponse>(request);
                            if (response.Data != null)
                            {
                                var cjProduct =
                                    response.Data.Data.FirstOrDefault(i => i.Sku.ToLower() == product.Sku.ToLower());
                                if (cjProduct != null)
                                    UpdateProduct(product.ProductId, cjProduct.Price, StockStatus.instock);
                                else
                                    UpdateProduct(product.ProductId, product.Price, StockStatus.outofstock);
                            }
                            else
                            {
                                UpdateProduct(product.ProductId, product.Price, StockStatus.outofstock);
                            }
                        }
                }
                catch (Exception e)
                {
                    Logger.Error($"{nameof(CjDropShippingSchedule)}: Failed due to {e.Message}.");
                }
            }
        }

        private static void UpdateProduct(int productId, string price, StockStatus stockStatus)
        {
            try
            {
                ProductRepository.UpdateProductPriceAndStock(productId, price, stockStatus);
                var wooCommerceClient = new RestClient(ConfigurationManager.AppSettings.Get("WooCommerceUrl"));
                var wooCommerceSecret = ConfigurationManager.AppSettings.Get("WooCommerceSecret");
                var wooCommerceKey = ConfigurationManager.AppSettings.Get("WooCommerceKey");

                wooCommerceClient.Authenticator = new HttpBasicAuthenticator(wooCommerceKey, wooCommerceSecret);

                var requestBody = new WoCommerceRequestBody
                {
                    StockStatus = stockStatus.ToString(),
                    Type = "simple"
                };
                if (!string.IsNullOrEmpty(price))
                {
                    var priceInDouble = Convert.ToDouble(price) +
                                        Convert.ToDouble(ConfigurationManager.AppSettings.Get("AddOnPrice"));
                    price = priceInDouble.ToString(CultureInfo.InvariantCulture);
                    requestBody.Price = price;
                    requestBody.RegularPrice = price;
                }

                var request = new RestRequest($"wp-json/wc/v3/products/{productId}", Method.PUT);
                request.AddJsonBody(JsonConvert.SerializeObject(requestBody));
                var response = wooCommerceClient.Execute(request);
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(
                        $"{nameof(UpdateProduct)}: is not successful due to StatusCode:{response.StatusCode}");
            }
            catch (Exception e)
            {
                Logger.Error($"{nameof(UpdateProduct)}: Failed to update product due to {e.Message}");
            }
        }

        private static Product GetProductById(int productId, RestClient wooCommerceClient, string wooCommerceKey,
            string wooCommerceSecret)
        {
            var request = new RestRequest($"wp-json/wc/v3/products/{productId}", Method.GET);
            request.AddParameter("consumer_key", wooCommerceKey);
            request.AddParameter("consumer_secret", wooCommerceSecret);
            var response = wooCommerceClient.Execute<Product>(request);
            return response.Data;
        }
    }
}