using _MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;

namespace _MultiShop.WebUI.Services.CargoServices.CargoCompanyService
{
    public interface ICargoCompanyService
    {
        Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto);
        Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto);
        Task DeleteCargoCompanyAsync(int id);
        Task<List<ResultCargoComnpanyDto>> GetAllCargoCompanyAsync();
        Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(int id);
    }
}
