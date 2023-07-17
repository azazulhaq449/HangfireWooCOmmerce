using System.Collections.Generic;

namespace SyncData.Models.CjDropShippingModels
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Data
    {
        public string Img { get; set; }
        public string ProductId { get; set; }
        public float ShortSku { get; set; }
        public string Price { get; set; }
        public double SellDiscount { get; set; }
        public string ShopId { get; set; }
        public string VariantId { get; set; }
        public string Title { get; set; }
        public string Sku { get; set; }
    }

    public class CjResponse
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public List<Data> Data { get; set; }
    }
}