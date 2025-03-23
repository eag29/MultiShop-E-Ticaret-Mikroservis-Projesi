using _MultiShop.Message.Dtos;
using _MultiShop.Message.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.Message.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessagesController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessagesController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessage()
        {
            var values = await _userMessageService.GetAllMessagesAsync();
            return Ok(values);
        }
        [HttpGet("GetMessageSendbox")]
        public async Task<IActionResult> GetMessageSendbox(string id)
        {
            var values = await _userMessageService.GetSendboxMessagesAsync(id);
            return Ok(values);
        }
        [HttpGet("GetMessageInbox")]
        public async Task<IActionResult> GetMessageInbox(string id)
        {
            var values = await _userMessageService.GetInboxMessagesAsync(id);
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdMessage(int id)
        {
            var values = await _userMessageService.GetByIdMessageAsync(id);
            return Ok(values);
        }
        [HttpGet("GetTotalMessageCount")]
        public async Task<IActionResult> GetTotalMessageCount()
        {
            int values = await _userMessageService.GetTotalMessageCount();
            return Ok(values);
        }
        [HttpGet("GetTotalMessageCountByReceiverId")]
        public async Task<IActionResult> GetTotalMessageCountByReceiverId(string id)
        {
            int values = await _userMessageService.GetTotalMessageCountByReceiverId(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            await _userMessageService.CreateMessageAsync(createMessageDto);
            return Ok("Mesaj başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMessageAsync(int id)
        {
            await _userMessageService.DeleteMessageAsync(id);
            return Ok("Mesaj silme işlemi başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            await _userMessageService.UpdateMessageAsync(updateMessageDto);
            return Ok("Mesaj güncelleme işlemi başarılı");
        }
    }
}
