using _MultiShop.Message.DAL.Context;
using _MultiShop.Message.DAL.Entities;
using _MultiShop.Message.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _MultiShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContext messageContext, IMapper mapper)
        {
            _messageContext = messageContext;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var values =  _mapper.Map<UserMessage>(createMessageDto);
            await _messageContext.UserMessages.AddAsync(values);
            await _messageContext.SaveChangesAsync();
        }
        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            var values = _mapper.Map<UserMessage>(updateMessageDto);
             _messageContext.UserMessages.Update(values);
            await _messageContext.SaveChangesAsync();
        }
        public async Task DeleteMessageAsync(int id)
        {
            var values = await _messageContext.UserMessages.FindAsync(id);
            _messageContext.UserMessages.Remove(values);
            await _messageContext.SaveChangesAsync();
        }
        public async Task<List<ResultMessageDto>> GetAllMessagesAsync()
        {
            var values = await _messageContext.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(values);
        }
        public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
        {
            var values = await _messageContext.UserMessages.FindAsync(id);
            return _mapper.Map<GetByIdMessageDto>(values);
        }
        public async Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.ReceiverId == id).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDto>>(values);
        }
        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessagesAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.SendedId == id).ToListAsync();
            return _mapper.Map<List<ResultSendboxMessageDto>>(values);
        }
        public async Task<int> GetTotalMessageCount()
        {
            var values = await _messageContext.UserMessages.CountAsync();
            return values;
        }

        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            int values = await _messageContext.UserMessages.Where(x => x.ReceiverId == id).CountAsync();
            return values;
        }
    }
}
