using _MultiShop.Message.Dtos;

namespace _MultiShop.Message.Services
{
    public interface IUserMessageService
    {
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int id);
        Task<List<ResultMessageDto>> GetAllMessagesAsync();
        Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string id);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessagesAsync(string id);
        Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
        Task<int> GetTotalMessageCount();
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
