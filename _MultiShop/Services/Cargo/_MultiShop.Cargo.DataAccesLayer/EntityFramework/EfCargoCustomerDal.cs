using _MultiShop.Cargo.DataAccesLayer.Abstract;
using _MultiShop.Cargo.DataAccesLayer.Concrete;
using _MultiShop.Cargo.DataAccesLayer.Repositories;
using _MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MultiShop.Cargo.DataAccesLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        private readonly CargoContext _context;

        public EfCargoCustomerDal(CargoContext context, CargoContext cargoContext) : base(context)
        {
            _context = cargoContext;
        }

        public CargoCustomer GetCargoCustomerById(string id)
        {
            var values = _context.CargoCustomers.Where(x => x.UserCustomerId == id).FirstOrDefault();
            return values;
        }
    }
}
