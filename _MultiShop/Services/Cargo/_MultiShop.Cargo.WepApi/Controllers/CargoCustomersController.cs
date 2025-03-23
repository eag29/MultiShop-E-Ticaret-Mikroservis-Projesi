using _MultiShop.Cargo.BusinessLayer.Abstract;
using _MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDto;
using _MultiShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.Cargo.WepApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult GetCargoCustomer()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargocustomer = new CargoCustomer()
            {
                Address = createCargoCustomerDto.Address,
                City = createCargoCustomerDto.City,
                District = createCargoCustomerDto.District,
                Email = createCargoCustomerDto.Email,
                Name = createCargoCustomerDto.Name,
                Surname = createCargoCustomerDto.Surname,
                Phone = createCargoCustomerDto.Phone,
                UserCustomerId = createCargoCustomerDto.UserCustomerId
            };
            _cargoCustomerService.TInsert(cargocustomer);
            return Ok("Kargo Ekleme işlemi başarılı");
        }
        [HttpGet("GetCargoCustomerById")]
        public IActionResult GetCargoCustomerById(string id)
        {
            return Ok(_cargoCustomerService.TCargoCustomerGetById(id));
        }
        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo Müşteri Silme İşlemi Başarıyla Yapıldı");
        }
        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargocustomer = new CargoCustomer()
            {
                CargoCustomerID = updateCargoCustomerDto.CargoCustomerID,
                Address = updateCargoCustomerDto.Address,
                City = updateCargoCustomerDto.City,
                District = updateCargoCustomerDto.District,
                Email = updateCargoCustomerDto.Email,
                Name = updateCargoCustomerDto.Name,
                Surname = updateCargoCustomerDto.Surname,
                Phone = updateCargoCustomerDto.Phone,
                UserCustomerId = updateCargoCustomerDto.UserCustomerId
            };
            _cargoCustomerService.TUpdate(cargocustomer);
            return Ok("Kargo Müşteri Güncelleme İşlemi Başarıyla Yapıldı");
        }
    }
}
