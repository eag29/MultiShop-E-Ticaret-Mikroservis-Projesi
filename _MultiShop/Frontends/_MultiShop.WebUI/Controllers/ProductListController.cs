using _MultiShop.DtoLayer.CommentDtos;
using _MultiShop.WebUI.Services.CommentServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace _MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICommentService _commentService;

        public ProductListController(IHttpClientFactory httpClientFactory, ICommentService commentService)
        {
            _httpClientFactory = httpClientFactory;
            _commentService = commentService;
        }

        void ProductViewBagList()
        {
            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = "Ürünler";
            ViewBag.directory3 = "Ürün Listesi";
        }
        public IActionResult AllProductList()
        {
            ProductViewBagList();
            return View();
        }
        public IActionResult Index(string id)
        {
            ProductViewBagList();
            ViewBag.i = id;
            return View();
        }
        public IActionResult ProductDetail(string id)
        {
            ProductViewBagList();
            ViewBag.x = id;
            return View();
        }
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            //createCommentDto.ImageUrl = "test";
            //createCommentDto.Rating = 1;
            //createCommentDto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //createCommentDto.Satus = false;
            //createCommentDto.ProductID = "";
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createCommentDto);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PostAsync("http://localhost:5237/services/comment/comments", content);

            // await _commentService.CreateCommentAsync(createCommentDto);
            //return RedirectToAction("Index", "ProductDetail", new { area = "Admin" });

            createCommentDto.ImageUrl = "test";
            createCommentDto.Rating = 1;
            createCommentDto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            createCommentDto.Satus = false;
            createCommentDto.ProductID = "65dc67a7705038bfa8fb1f87";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7098/api/Comments", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();

        }
    }
}
