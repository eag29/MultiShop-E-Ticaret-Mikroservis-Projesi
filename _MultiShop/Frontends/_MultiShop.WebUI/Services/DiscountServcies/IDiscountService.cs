using _MultiShop.DtoLayer.DiscountDtos;

namespace _MultiShop.WebUI.Services.DiscountServcies
{
    public interface IDiscountService
    {
        Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code);
        Task<int> GetDiscountCouponRate(string code);
    }
}
