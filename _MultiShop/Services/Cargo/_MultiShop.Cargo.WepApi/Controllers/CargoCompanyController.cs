using _MultiShop.Cargo.BusinessLayer.Abstract;
using _MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDto;
using _MultiShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.Cargo.WepApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargocompanyService;

        public CargoCompanyController(ICargoCompanyService cargocompanyService)
        {
            _cargocompanyService = cargocompanyService;
        }
        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _cargocompanyService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult CargoCompanyGetById(int id)
        {
            var values = _cargocompanyService.TBetById(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyName = createCargoCompanyDto.CargoCompanyName
            };
            _cargocompanyService.TInsert(cargoCompany);
            return Ok("Kargo Şirketi başarıyla eklendi");
        }
        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyID = updateCargoCompanyDto.CargoCompanyID,
                CargoCompanyName = updateCargoCompanyDto.CargoCompanyName
            };
            _cargocompanyService.TUpdate(cargoCompany);
            return Ok("Kargo Şirketi başarıyla güncellendi");
        }
        [HttpDelete]
        public IActionResult RemoveCargoCompany(int id)
        {
            _cargocompanyService.TDelete(id);
            return Ok("Kargo Şirketi başarıyla silindi");
        }
    }
}
