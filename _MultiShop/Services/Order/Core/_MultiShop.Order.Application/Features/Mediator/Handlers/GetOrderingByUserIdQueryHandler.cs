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
    public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
    {
        private readonly IOrderingRepository _orderingRepository;

        public GetOrderingByUserIdQueryHandler(IOrderingRepository orderingRepository)
        {
            _orderingRepository = orderingRepository;
        }

        public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values = _orderingRepository.GetOrderingsByUserID(request.ID);
            return values.Select(x => new GetOrderingByUserIdQueryResult
            {
                OrderDate = x.OrderDate,
                OrderingID = x.OrderingID,
                TotalPrice = x.TotalPrice,
                UserID = x.UserID,
            }).ToList();
        }
    }
}
