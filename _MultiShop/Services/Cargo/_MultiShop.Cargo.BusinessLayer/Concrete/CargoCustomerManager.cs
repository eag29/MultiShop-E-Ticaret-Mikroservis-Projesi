using _MultiShop.Cargo.BusinessLayer.Abstract;
using _MultiShop.Cargo.DataAccesLayer.Abstract;
using _MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomerDal;

        public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
        {
            _cargoCustomerDal = cargoCustomerDal;
        }
        public void TInsert(CargoCustomer entity)
        {
            _cargoCustomerDal.Insert(entity);
        }
        public void TUpdate(CargoCustomer entity)
        {
            _cargoCustomerDal.Update(entity);
        }
        public void TDelete(int id)
        {
            _cargoCustomerDal.Delete(id);
        }
        public CargoCustomer TBetById(int id)
        {
            return _cargoCustomerDal.GetById(id);
        }
        public List<CargoCustomer> TGetAll()
        {
            return _cargoCustomerDal.GetAll();
        }
    }
}
