using _MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MultiShop.Order.Application.Interfaces
{
    public interface IOrderingRepository
    {
        public List<Ordering> GetOrderingsByUserID(string id);
    }
}
