﻿namespace _MultiShop.Catalog.Dtos.FeatureSliderDto
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
