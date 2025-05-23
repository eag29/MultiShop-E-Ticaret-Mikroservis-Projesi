﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MultiShop.DtoLayer.CatalogDtos.FeaureSliderDtos
{
    public class UpdateFeatureSliderDto
    {
        public string FeatureSliderID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public string CategoryID { get; set; }
    }
}
