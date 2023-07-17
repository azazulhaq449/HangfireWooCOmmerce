using System.ComponentModel.DataAnnotations.Schema;

namespace SyncData.Models.DB
{
    [Table("Product")]
    public class Product
    {
        public long Id { get; set; }

        public int ProductId { get; set; }

        public string Sku { get; set; }

        public string Price { get; set; }

        public string StockStatus { get; set; }
    }
}