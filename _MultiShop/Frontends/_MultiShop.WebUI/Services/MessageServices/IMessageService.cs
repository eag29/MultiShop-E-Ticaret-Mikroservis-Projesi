using _MultiShop.DtoLayer.MessageDtos;

namespace _MultiShop.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string id);
        Task<List<ResultISendboxMessageDto>> GetSendboxMessagesAsync(string id);
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
