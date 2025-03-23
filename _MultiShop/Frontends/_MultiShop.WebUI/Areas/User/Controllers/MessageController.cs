using _MultiShop.WebUI.Services.Interfaces;
using _MultiShop.WebUI.Services.MessageServices;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IuserService _userService;

        public MessageController(IMessageService messageService, IuserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        public async Task<IActionResult> Inbox()
        {
            var user = await _userService.GetUserInfo();
            var values = await _messageService.GetInboxMessagesAsync(user.Id);
            return View(values);
        }
        public async Task<IActionResult> Sendbox()
        {
            var user = await _userService.GetUserInfo();
            var values = await _messageService.GetSendboxMessagesAsync(user.Id);
            return View(values);
        }
    }
}
