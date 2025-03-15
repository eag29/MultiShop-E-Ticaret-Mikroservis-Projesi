using _MultiShop.Order.Application.Interfaces;
using _MultiShop.Order.Domain.Entities;
using _MultiShop.Order.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MultiShop.Order.Persistence.Repositories
{
    public class OrderingRepository : IOrderingRepository
    {
        private readonly OrderContext _context;

        public OrderingRepository(OrderContext context)
        {
            _context = context;
        }

        public List<Ordering> GetOrderingsByUserID(string id)
        {
            var values = _context.Orderings.Where(x => x.UserID == id).ToList();
            return values;
        }
    }
}
