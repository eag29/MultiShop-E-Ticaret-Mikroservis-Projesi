using _MultiShop.Order.Application.Features.CQRS.Queires.AddressQueries;
using _MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using _MultiShop.Order.Application.Interfaces;
using _MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery getAddressByIdQuery)
        {
            var values = await _repository.GetByIdAsync(getAddressByIdQuery.ID);
            return new GetAddressByIdQueryResult
            {
                UserID = values.UserID,
                Name = values.Name,
                Surname = values.Surname,
                Email = values.Email,
                Phone = values.Phone,
                Country = values.Country,
                District = values.District,
                City = values.City,
                Detail1 = values.Detail1,
                Detail2 = values.Detail2,
                Description = values.Description,
                ZipCode = values.ZipCode,
            };
        }
    }
}
