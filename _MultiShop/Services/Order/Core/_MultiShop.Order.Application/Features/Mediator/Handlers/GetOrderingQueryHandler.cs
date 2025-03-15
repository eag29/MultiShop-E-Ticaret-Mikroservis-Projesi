using _MultiShop.Order.Application.Features.Mediator.Queires;
using _MultiShop.Order.Application.Features.Mediator.Results;
using _MultiShop.Order.Application.Interfaces;
using _MultiShop.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MultiShop.Order.Application.Features.Mediator.Handlers
{
    public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderingQueryResult
            {
                OrderingID = x.OrderingID,
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice,
                UserID = x.UserID,
            }).ToList();
        }
    }
}
