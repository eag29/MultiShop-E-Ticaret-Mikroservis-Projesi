using _MultiShop.Order.Application.Features.Mediator.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MultiShop.Order.Application.Features.Mediator.Queires
{
    public class GetOrderingQuery:IRequest<List<GetOrderingQueryResult>>
    {
    }
}
