using _MultiShop.IdentityServer.Dtos;
using _MultiShop.IdentityServer.Models;
using IdentityServer4.Hosting.LocalApiAuthentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace _MultiShop.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> RegisterList(UserRegisterDto dto)
        {
            var values = new ApplicationUser()
            {
                UserName = dto.Username,
                Email = dto.Email,
                Name = dto.Name,
                Surname = dto.Surname,
            };

            var result = await _userManager.CreateAsync(values,dto.Password);
            if (result.Succeeded)
            {
                return Ok("Kullanıcı başarıyla eklendi");
            }
            else
            {
                return Ok("Bir hata oluştu tekrar deneyiniz");
            }
        }
    }
}
