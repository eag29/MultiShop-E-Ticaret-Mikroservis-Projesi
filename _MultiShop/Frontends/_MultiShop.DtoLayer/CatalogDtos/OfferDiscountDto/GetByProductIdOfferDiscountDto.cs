using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MultiShop.DtoLayer.CatalogDtos.OfferDiscountDto
{
    public class GetByProductIdOfferDiscountDto
    {
        public string OfferDiscountID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public string ButtonTitle { get; set; }
        public string ProductID { get; set; }
    }
}
