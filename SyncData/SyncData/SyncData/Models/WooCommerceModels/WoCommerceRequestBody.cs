using Newtonsoft.Json;

namespace SyncData.Models.WooCommerceModels
{
    public class WoCommerceRequestBody
    {
        [JsonProperty("price")] public string Price { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("regular_price")] public string RegularPrice { get; set; }

        [JsonProperty("stock_status")] public string StockStatus { get; set; }
    }
}