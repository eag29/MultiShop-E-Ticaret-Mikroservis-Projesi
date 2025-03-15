using _MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using _MultiShop.Order.Application.Interfaces;
using _MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var value = await _repository.GetByIdAsync(updateAddressCommand.AddressID);
            value.UserID = updateAddressCommand.UserID;
            value.Name = updateAddressCommand.Name;
            value.Surname = updateAddressCommand.Surname;
            value.Email = updateAddressCommand.Email;
            value.Phone = updateAddressCommand.Phone;
            value.Country = updateAddressCommand.Country;
            value.District = updateAddressCommand.District;
            value.City = updateAddressCommand.City;
            value.Detail1 = updateAddressCommand.Detail1;
            value.Detail2 = updateAddressCommand.Detail2;
            value.Description = updateAddressCommand.Description;
            value.ZipCode = updateAddressCommand.ZipCode;
            await _repository.UpdateAsync(value);
        }
    }
}
