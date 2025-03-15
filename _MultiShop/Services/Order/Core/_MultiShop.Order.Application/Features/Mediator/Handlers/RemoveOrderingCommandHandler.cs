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
    public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public RemoveOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(values);
            return Unit.Value;
        }
    }
}
