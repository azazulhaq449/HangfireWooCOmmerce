using System.Collections.Generic;
using SyncData.Models.WooCommerceModels;
using Product = SyncData.Models.DB.Product;

namespace SyncData.Services.Repository
{
    public interface IProductRepository
    {
        void AddProductSku(string sku, int productId);
        List<Product> GetAllProducts();
        void UpdateProductPriceAndStock(int productId, string price, StockStatus stockStatus);
    }
}