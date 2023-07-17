using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using log4net;
using Microsoft.Ajax.Utilities;
using SyncData.Models.DB;
using SyncData.Models.WooCommerceModels;
using Product = SyncData.Models.DB.Product;

namespace SyncData.Services.Repository
{
    public class ProductRepository : IProductRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ProductRepository));
        private static readonly SyncDb Db = new SyncDb();
        private readonly object _lock = new object();

        public void AddProductSku(string sku, int productId)
        {
            try
            {
                lock (_lock)
                {
                    var isSameSkuExist = Db.Products.Any(i => i.Sku.ToLower() == sku.ToLower());
                    if (!isSameSkuExist)
                    {
                        Db.Products.Add(new Product
                        {
                            Sku = sku,
                            ProductId = productId
                        });
                        Db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Error($"{nameof(AddProductSku)}: Failed to add sku:{sku} message:{e.Message}");
            }
        }

        public List<Product> GetAllProducts()
        {
            var result = new List<Product>();
            try
            {
                lock (_lock)
                {
                    result = Db.Products.OrderByDescending(i => i.Id).ToList();
                }
            }
            catch (Exception e)
            {
                Logger.Error($"{nameof(GetAllProducts)}: Failed to get all products message:{e.Message}");
            }

            return result;
        }

        public void UpdateProductPriceAndStock(int productId, string price, StockStatus stockStatus)
        {
            try
            {
                lock (_lock)
                {
                    var product = Db.Products.FirstOrDefault(i => i.ProductId == productId);
                    if (product != null)
                    {
                        product.Id = product.Id;
                        product.Sku = product.Sku;
                        product.ProductId = product.ProductId;
                        product.StockStatus = stockStatus.ToString();
                        if (!price.IsNullOrWhiteSpace()) product.Price = price;
                        Db.Products.AddOrUpdate(product);
                        Db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Error(
                    $"{nameof(UpdateProductPriceAndStock)}: Failed to update product:{productId} due to :{e.Message}");
            }
        }
    }
}