using _MultiShop.Order.Application.Features.Mediator.Commands;
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
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.OrderingID);
            values.OrderDate = request.OrderDate;
            values.UserID = request.UserID;
            values.TotalPrice = request.TotalPrice;
            await _repository.UpdateAsync(values);
            return Unit.Value;
        }
    }
}
