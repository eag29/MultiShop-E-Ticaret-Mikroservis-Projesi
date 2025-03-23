using _MultiShop.Message.DAL.Entities;
using _MultiShop.Message.Dtos;
using _MultiShop.Message.Services;
using AutoMapper;

namespace _MultiShop.Message.Mapping
{
    public class GeneralMapping: Profile
    {
        public GeneralMapping()
        {
            CreateMap<UserMessage, CreateMessageDto>().ReverseMap();
            CreateMap<UserMessage, UpdateMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultInboxMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultSendboxMessageDto>().ReverseMap();
            CreateMap<UserMessage, GetByIdMessageDto>().ReverseMap();
        }
    }
}
