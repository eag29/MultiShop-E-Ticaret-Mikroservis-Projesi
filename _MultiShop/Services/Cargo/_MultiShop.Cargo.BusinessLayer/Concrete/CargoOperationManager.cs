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
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal _cargoOperationDal;

        public CargoOperationManager(ICargoOperationDal cargoOperationDal)
        {
            _cargoOperationDal = cargoOperationDal;
        }

        public void TInsert(CargoOperation entity)
        {
            _cargoOperationDal.Insert(entity);
        }
        public void TUpdate(CargoOperation entity)
        {
            _cargoOperationDal.Update(entity);
        }
        public void TDelete(int id)
        {
            _cargoOperationDal.Delete(id);
        }
        public CargoOperation TBetById(int id)
        {
            return _cargoOperationDal.GetById(id);
        }
        public List<CargoOperation> TGetAll()
        {
            return _cargoOperationDal.GetAll();
        }
    }
}
