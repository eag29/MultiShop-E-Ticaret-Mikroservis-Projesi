using _MultiShop.Catalog.Dtos.AboutDtos;
using _MultiShop.Catalog.Dtos.BrandDtos;
using _MultiShop.Catalog.Dtos.CategoryDtos;
using _MultiShop.Catalog.Dtos.ContactDtos;
using _MultiShop.Catalog.Dtos.FeatureDtos;
using _MultiShop.Catalog.Dtos.FeatureSliderDto;
using _MultiShop.Catalog.Dtos.OfferDiscountDto;
using _MultiShop.Catalog.Dtos.ProductDetailDtos;
using _MultiShop.Catalog.Dtos.ProductDtos;
using _MultiShop.Catalog.Dtos.ProductImageDtos;
using _MultiShop.Catalog.Dtos.SpecialOfferDtos;
using _MultiShop.Catalog.Entities;
using AutoMapper;

namespace _MultiShop.Catalog.Mapping
{
    public class GeneralMapping: Profile
    {
        //Mapping: Entities ile Dtos eşleşmesini yapar.
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();

            CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, FeatureSliderGetByIdDto>().ReverseMap();
            CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();

            CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, GetByIdSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();

            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, FeatureGetByIdDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();

            CreateMap<OfferDiscount, ResultOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, GetByIdOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, CreateOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, UpdateOfferDiscountDto>().ReverseMap();

            CreateMap<Brand, ResultBrandDto>().ReverseMap();
            CreateMap<Brand, GetByIdBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();

            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, GetByIdAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();

            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, GetByIdContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
        }
    }
}
