using _MultiShop.WebUI.Services.CommentServices;
using _MultiShop.WebUI.Services.Interfaces;
using _MultiShop.WebUI.Services.MessageServices;
using _MultiShop.WebUI.Services.StatisticServices.CommentServices;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutHeaderComponentPartial: ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IuserService _userService;
        private readonly ICommentStatisticService _commentStatisticService;

        public _AdminLayoutHeaderComponentPartial(IMessageService messageService, IuserService userService, ICommentStatisticService commentStatisticService)
        {
            _messageService = messageService;
            _userService = userService;
            _commentStatisticService = commentStatisticService;
        }

        //public IViewComponentResult Invoke()
        //{
        //    return View();
        //}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();

            var messageCount = await _messageService.GetTotalMessageCountByReceiverId(user.Id);
            ViewBag.MessageCount = messageCount;

            var totalCommentCount = await _commentStatisticService.GetTotalCommentCount();
            ViewBag.TotalCommentCount = totalCommentCount;

            return View();
        }
    }
}
