using _MultiShop.Comment.Context;
using _MultiShop.Comment.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _MultiShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public CommentsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentContext.UsserComments.ToList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _commentContext.UsserComments.Find(id);
            return Ok(value);
        }
        [HttpGet("CommentListByProductId/{id}")]
        public IActionResult CommentListByProductId(string id)
        {
            var value = _commentContext.UsserComments.Where(x => x.ProductID == id).ToList();
            return Ok(value);
        }
        [HttpGet("GetActiveCommentCount")]
        public IActionResult GetActiveCommentCount()
        {
            int value = _commentContext.UsserComments.Where(x => x.Satus == true).Count();
            return Ok(value);
        }
        [HttpGet("GetPassiveCommentCount")]
        public IActionResult GetPassiveCommentCount()
        {
            int value = _commentContext.UsserComments.Where(x => x.Satus == false).Count();
            return Ok(value);
        }
        [HttpGet("GetTotalCommentCount")]
        public IActionResult GetTotalCommentCount()
        {
            int value = _commentContext.UsserComments.Count();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateComment(UsserComment usserComment)
        {
            _commentContext.UsserComments.Add(usserComment);
            _commentContext.SaveChanges();
            return Ok("Yorum başarıyla eklendi");
        }
        [HttpPut]
        public IActionResult UpdateComment(UsserComment usserComment)
        {
            _commentContext.UsserComments.Update(usserComment);
            _commentContext.SaveChanges();
            return Ok("Yorum başarıyla güncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var value = _commentContext.UsserComments.Find(id);
            _commentContext.UsserComments.Remove(value);
            _commentContext.SaveChanges();
            return Ok("Yorum başarıyla silindi");
        }
    }
}
