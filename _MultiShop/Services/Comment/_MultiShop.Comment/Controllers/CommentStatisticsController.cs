using _MultiShop.Comment.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _MultiShop.Comment.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentStatisticsController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public CommentStatisticsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentCount()
        {
            var values = await _commentContext.UsserComments.CountAsync();
            return Ok(values);
        }
    }
}
