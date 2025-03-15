using _MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using _MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using _MultiShop.Order.Application.Interfaces;
using _MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            {
                UserID = x.UserID,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Phone = x.Phone,
                Country = x.Country,
                District = x.District,
                City = x.City,
                Detail1 = x.Detail1,
                Detail2 = x.Detail2,
                Description = x.Description,
                ZipCode = x.ZipCode,
            }).ToList();
        }
    }
}
