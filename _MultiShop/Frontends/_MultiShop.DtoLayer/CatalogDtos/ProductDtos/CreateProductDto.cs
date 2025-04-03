namespace _MultiShop.DtoLayer.CatalogDtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string ProductDescription { get; set; }
        public string ProductSubDescription { get; set; }
        public string ProductInfo { get; set; }
        public string CategoryID { get; set; }
    }
}
