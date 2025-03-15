using _MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using _MultiShop.Order.Application.Interfaces;
using _MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class RemoveAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public RemoveAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveAddressCommand removeAddressCommand)
        {
            var values = await _repository.GetByIdAsync(removeAddressCommand.ID);
            await _repository.DeleteAsync(values);
        }
    }
}
