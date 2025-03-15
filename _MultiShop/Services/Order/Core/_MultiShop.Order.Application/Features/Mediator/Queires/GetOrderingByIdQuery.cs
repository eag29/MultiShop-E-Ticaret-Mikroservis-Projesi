using _MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using _MultiShop.Order.Application.Features.Mediator.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MultiShop.Order.Application.Features.Mediator.Queires
{
    public class GetOrderingByIdQuery: IRequest<GetOrderingByIdQueryResult>
    {
        public int Id { get; set; }

        public GetOrderingByIdQuery(int id)
        {
            Id = id;
        }
    }
}
