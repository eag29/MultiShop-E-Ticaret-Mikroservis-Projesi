using _MultiShop.DtoLayer.CommentDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;
using _MultiShop.WebUI.Services.CommentServices;

namespace _MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICommentService _commentService;

        public CommentController(IHttpClientFactory httpClientFactory, ICommentService commentService)
        {
            _httpClientFactory = httpClientFactory;
            _commentService = commentService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Yorum İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Listesi";

            var values = await _commentService.GetAllCommentAsync();
            return View(values);
        }

        [Route("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            await _commentService.DeleteCommentAsync(id);
            return RedirectToAction("Index", "Comment", new { area = "Admin" });
        }
        [Route("UpdateComment/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateComment(string id)
        {
            ViewBag.v0 = "Yorum İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Listesi";

            var values = await _commentService.GetByIdCommentAsync(id);
            return View(values);
        }

        [Route("UpdateComment/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            await _commentService.UpdateCommentAsync(updateCommentDto);
            return RedirectToAction("Index", "Comment", new { area = "Admin" });
        }
    }
}
