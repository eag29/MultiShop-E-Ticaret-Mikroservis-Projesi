using _MultiShop.Catalog.Entities;

namespace _MultiShop.Catalog.Dtos.ProductDetailDtos
{
    public class GetByIdProductDetailDto
    {
        public string ProductDetailID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }
        public string ProductID { get; set; }
    }
}
