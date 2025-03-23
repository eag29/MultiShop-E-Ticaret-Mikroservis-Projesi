using _MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace _MultiShop.WebUI.Services.CargoServices.CargoCustomerService
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomeByIdDto> GetByIdCargoCustomerInfoAsync(string id);
    }
}
