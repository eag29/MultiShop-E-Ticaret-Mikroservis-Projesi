using _MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using _MultiShop.WebUI.Models;
using _MultiShop.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace _MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IIdentityService _identityService;

        public LoginController(IHttpClientFactory httpClientFactory,IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _identityService = identityService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignInDto signInDto)
        {
            await _identityService.SignIn(signInDto);
            return RedirectToAction("Index", "User");
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _identityService.Logout();
            return RedirectToAction("Index", "Login");
        }
    }
}
