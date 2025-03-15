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
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }

        public void TInsert(CargoDetail entity)
        {
            _cargoDetailDal.Insert(entity);
        }
        public void TUpdate(CargoDetail entity)
        {
            _cargoDetailDal.Update(entity);
        }
        public void TDelete(int id)
        {
            _cargoDetailDal.Delete(id);
        }
        public CargoDetail TBetById(int id)
        {
            return _cargoDetailDal.GetById(id);
        }
        public List<CargoDetail> TGetAll()
        {
            return _cargoDetailDal.GetAll();
        }
    }
}
