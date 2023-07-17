using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SyncData.Models.WooCommerceModels
{
    public class Dimensions
    {
        [JsonPropertyName("length")] public string Length { get; set; }

        [JsonPropertyName("width")] public string Width { get; set; }

        [JsonPropertyName("height")] public string Height { get; set; }
    }

    public class Category
    {
        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("slug")] public string Slug { get; set; }
    }

    public class Tag
    {
        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("slug")] public string Slug { get; set; }
    }

    public class Image
    {
        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("date_created")] public DateTime DateCreated { get; set; }

        [JsonPropertyName("date_created_gmt")] public DateTime DateCreatedGmt { get; set; }

        [JsonPropertyName("date_modified")] public DateTime DateModified { get; set; }

        [JsonPropertyName("date_modified_gmt")]
        public DateTime DateModifiedGmt { get; set; }

        [JsonPropertyName("src")] public string Src { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("alt")] public string Alt { get; set; }
    }

    public class Attribute
    {
        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("position")] public int Position { get; set; }

        [JsonPropertyName("visible")] public bool Visible { get; set; }

        [JsonPropertyName("variation")] public bool Variation { get; set; }

        [JsonPropertyName("options")] public List<string> Options { get; set; }
    }

    public class MetaData
    {
        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("key")] public string Key { get; set; }

        [JsonPropertyName("value")] public object Value { get; set; }
    }

    public class Robots
    {
        [JsonPropertyName("index")] public string Index { get; set; }

        [JsonPropertyName("follow")] public string Follow { get; set; }

        [JsonPropertyName("max-snippet")] public string MaxSnippet { get; set; }

        [JsonPropertyName("max-image-preview")]
        public string MaxImagePreview { get; set; }

        [JsonPropertyName("max-video-preview")]
        public string MaxVideoPreview { get; set; }
    }

    public class OgImage
    {
        [JsonPropertyName("width")] public int Width { get; set; }

        [JsonPropertyName("height")] public int Height { get; set; }

        [JsonPropertyName("url")] public string Url { get; set; }

        [JsonPropertyName("path")] public string Path { get; set; }

        [JsonPropertyName("size")] public string Size { get; set; }

        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("alt")] public string Alt { get; set; }

        [JsonPropertyName("pixels")] public int Pixels { get; set; }

        [JsonPropertyName("type")] public string Type { get; set; }
    }

    public class Logo
    {
        [JsonPropertyName("@type")] public string Type { get; set; }

        [JsonPropertyName("@id")] public string Id { get; set; }

        [JsonPropertyName("inLanguage")] public string InLanguage { get; set; }

        [JsonPropertyName("url")] public string Url { get; set; }

        [JsonPropertyName("contentUrl")] public string ContentUrl { get; set; }

        [JsonPropertyName("width")] public int Width { get; set; }

        [JsonPropertyName("height")] public int Height { get; set; }

        [JsonPropertyName("caption")] public string Caption { get; set; }
    }

    public class Image2
    {
        [JsonPropertyName("@id")] public string Id { get; set; }
    }

    public class Publisher
    {
        [JsonPropertyName("@id")] public string Id { get; set; }
    }

    public class PotentialAction
    {
        [JsonPropertyName("@type")] public string Type { get; set; }

        [JsonPropertyName("target")] public object Target { get; set; }

        [JsonPropertyName("query-input")] public string QueryInput { get; set; }
    }

    public class IsPartOf
    {
        [JsonPropertyName("@id")] public string Id { get; set; }
    }

    public class PrimaryImageOfPage
    {
        [JsonPropertyName("@id")] public string Id { get; set; }
    }

    public class Breadcrumb
    {
        [JsonPropertyName("@id")] public string Id { get; set; }
    }

    public class ItemListElement
    {
        [JsonPropertyName("@type")] public string Type { get; set; }

        [JsonPropertyName("position")] public int Position { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("item")] public string Item { get; set; }
    }

    public class Graph
    {
        [JsonPropertyName("@type")] public string Type { get; set; }

        [JsonPropertyName("@id")] public string Id { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("url")] public string Url { get; set; }

        [JsonPropertyName("sameAs")] public List<string> SameAs { get; set; }

        [JsonPropertyName("logo")] public Logo Logo { get; set; }

        [JsonPropertyName("image")] public Image Image { get; set; }

        [JsonPropertyName("description")] public string Description { get; set; }

        [JsonPropertyName("publisher")] public Publisher Publisher { get; set; }

        [JsonPropertyName("potentialAction")] public List<PotentialAction> PotentialAction { get; set; }

        [JsonPropertyName("inLanguage")] public string InLanguage { get; set; }

        [JsonPropertyName("contentUrl")] public string ContentUrl { get; set; }

        [JsonPropertyName("width")] public int? Width { get; set; }

        [JsonPropertyName("height")] public int? Height { get; set; }

        [JsonPropertyName("isPartOf")] public IsPartOf IsPartOf { get; set; }

        [JsonPropertyName("primaryImageOfPage")]
        public PrimaryImageOfPage PrimaryImageOfPage { get; set; }

        [JsonPropertyName("datePublished")] public DateTime? DatePublished { get; set; }

        [JsonPropertyName("dateModified")] public DateTime? DateModified { get; set; }

        [JsonPropertyName("breadcrumb")] public Breadcrumb Breadcrumb { get; set; }

        [JsonPropertyName("itemListElement")] public List<ItemListElement> ItemListElement { get; set; }

        [JsonPropertyName("caption")] public string Caption { get; set; }
    }

    public class Schema
    {
        [JsonPropertyName("@context")] public string Context { get; set; }

        [JsonPropertyName("@graph")] public List<Graph> Graph { get; set; }
    }

    public class TwitterMisc
    {
        [JsonPropertyName("Estimated reading time")]
        public string EstimatedReadingTime { get; set; }
    }

    public class YoastHeadJson
    {
        [JsonPropertyName("title")] public string Title { get; set; }

        [JsonPropertyName("robots")] public Robots Robots { get; set; }

        [JsonPropertyName("canonical")] public string Canonical { get; set; }

        [JsonPropertyName("og_locale")] public string OgLocale { get; set; }

        [JsonPropertyName("og_type")] public string OgType { get; set; }

        [JsonPropertyName("og_title")] public string OgTitle { get; set; }

        [JsonPropertyName("og_description")] public string OgDescription { get; set; }

        [JsonPropertyName("og_url")] public string OgUrl { get; set; }

        [JsonPropertyName("og_site_name")] public string OgSiteName { get; set; }

        [JsonPropertyName("article_publisher")]
        public string ArticlePublisher { get; set; }

        [JsonPropertyName("article_modified_time")]
        public DateTime ArticleModifiedTime { get; set; }

        [JsonPropertyName("og_image")] public List<OgImage> OgImage { get; set; }

        [JsonPropertyName("twitter_card")] public string TwitterCard { get; set; }

        [JsonPropertyName("schema")] public Schema Schema { get; set; }

        [JsonPropertyName("description")] public string Description { get; set; }

        [JsonPropertyName("twitter_misc")] public TwitterMisc TwitterMisc { get; set; }
    }

    public class Self
    {
        [JsonPropertyName("href")] public string Href { get; set; }
    }

    public class Collection
    {
        [JsonPropertyName("href")] public string Href { get; set; }
    }

    public class Links
    {
        [JsonPropertyName("self")] public List<Self> Self { get; set; }

        [JsonPropertyName("collection")] public List<Collection> Collection { get; set; }
    }

    public class Product
    {
        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("slug")] public string Slug { get; set; }

        [JsonPropertyName("permalink")] public string Permalink { get; set; }

        [JsonPropertyName("date_created")] public DateTime DateCreated { get; set; }

        [JsonPropertyName("date_created_gmt")] public DateTime DateCreatedGmt { get; set; }

        [JsonPropertyName("date_modified")] public DateTime DateModified { get; set; }

        [JsonPropertyName("date_modified_gmt")]
        public DateTime DateModifiedGmt { get; set; }

        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("status")] public string Status { get; set; }

        [JsonPropertyName("featured")] public bool Featured { get; set; }

        [JsonPropertyName("catalog_visibility")]
        public string CatalogVisibility { get; set; }

        [JsonPropertyName("description")] public string Description { get; set; }

        [JsonPropertyName("short_description")]
        public string ShortDescription { get; set; }

        [JsonPropertyName("sku")] public string Sku { get; set; }

        [JsonPropertyName("price")] public string Price { get; set; }

        [JsonPropertyName("regular_price")] public string RegularPrice { get; set; }

        [JsonPropertyName("sale_price")] public string SalePrice { get; set; }

        [JsonPropertyName("date_on_sale_from")]
        public object DateOnSaleFrom { get; set; }

        [JsonPropertyName("date_on_sale_from_gmt")]
        public object DateOnSaleFromGmt { get; set; }

        [JsonPropertyName("date_on_sale_to")] public object DateOnSaleTo { get; set; }

        [JsonPropertyName("date_on_sale_to_gmt")]
        public object DateOnSaleToGmt { get; set; }

        [JsonPropertyName("on_sale")] public bool OnSale { get; set; }

        [JsonPropertyName("purchasable")] public bool Purchasable { get; set; }

        [JsonPropertyName("total_sales")] public int TotalSales { get; set; }

        [JsonPropertyName("virtual")] public bool Virtual { get; set; }

        [JsonPropertyName("downloadable")] public bool Downloadable { get; set; }

        [JsonPropertyName("downloads")] public List<object> Downloads { get; set; }

        [JsonPropertyName("download_limit")] public int DownloadLimit { get; set; }

        [JsonPropertyName("download_expiry")] public int DownloadExpiry { get; set; }

        [JsonPropertyName("external_url")] public string ExternalUrl { get; set; }

        [JsonPropertyName("button_text")] public string ButtonText { get; set; }

        [JsonPropertyName("tax_status")] public string TaxStatus { get; set; }

        [JsonPropertyName("tax_class")] public string TaxClass { get; set; }

        [JsonPropertyName("manage_stock")] public bool ManageStock { get; set; }

        [JsonPropertyName("stock_quantity")] public int? StockQuantity { get; set; }

        [JsonPropertyName("backorders")] public string Backorders { get; set; }

        [JsonPropertyName("backorders_allowed")]
        public bool BackordersAllowed { get; set; }

        [JsonPropertyName("backordered")] public bool Backordered { get; set; }

        [JsonPropertyName("low_stock_amount")] public int? LowStockAmount { get; set; }

        [JsonPropertyName("sold_individually")]
        public bool SoldIndividually { get; set; }

        [JsonPropertyName("weight")] public string Weight { get; set; }

        [JsonPropertyName("dimensions")] public Dimensions Dimensions { get; set; }

        [JsonPropertyName("shipping_required")]
        public bool ShippingRequired { get; set; }

        [JsonPropertyName("shipping_taxable")] public bool ShippingTaxable { get; set; }

        [JsonPropertyName("shipping_class")] public string ShippingClass { get; set; }

        [JsonPropertyName("shipping_class_id")]
        public int ShippingClassId { get; set; }

        [JsonPropertyName("reviews_allowed")] public bool ReviewsAllowed { get; set; }

        [JsonPropertyName("average_rating")] public string AverageRating { get; set; }

        [JsonPropertyName("rating_count")] public int RatingCount { get; set; }

        [JsonPropertyName("upsell_ids")] public List<object> UpsellIds { get; set; }

        [JsonPropertyName("cross_sell_ids")] public List<object> CrossSellIds { get; set; }

        [JsonPropertyName("parent_id")] public int ParentId { get; set; }

        [JsonPropertyName("purchase_note")] public string PurchaseNote { get; set; }

        [JsonPropertyName("categories")] public List<Category> Categories { get; set; }

        [JsonPropertyName("tags")] public List<Tag> Tags { get; set; }

        [JsonPropertyName("images")] public List<Image> Images { get; set; }

        [JsonPropertyName("attributes")] public List<Attribute> Attributes { get; set; }

        [JsonPropertyName("default_attributes")]
        public List<object> DefaultAttributes { get; set; }

        [JsonPropertyName("variations")] public List<int> Variations { get; set; }

        [JsonPropertyName("grouped_products")] public List<object> GroupedProducts { get; set; }

        [JsonPropertyName("menu_order")] public int MenuOrder { get; set; }

        [JsonPropertyName("price_html")] public string PriceHtml { get; set; }

        [JsonPropertyName("related_ids")] public List<int> RelatedIds { get; set; }

        [JsonPropertyName("meta_data")] public List<MetaData> MetaData { get; set; }

        [JsonPropertyName("stock_status")] public string StockStatus { get; set; }

        [JsonPropertyName("yoast_head")] public string YoastHead { get; set; }

        [JsonPropertyName("yoast_head_json")] public YoastHeadJson YoastHeadJson { get; set; }

        [JsonPropertyName("_links")] public Links Links { get; set; }
    }
}