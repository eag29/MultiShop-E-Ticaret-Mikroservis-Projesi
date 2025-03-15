using _MultiShop.Discount.Dtos;

namespace _MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int id);
        Task<List<ResultCouponDto>> GetAllCouponAsync();
        Task<ResultCouponDto> GetCodeDetailByCode(string code);
        Task<GetByIdCouponDto> GetByIdCouponAsync(int id);
        int GetDiscountCouponRateAsync(string code);
    }
}
