﻿using _MultiShop.Cargo.BusinessLayer.Abstract;
using _MultiShop.Cargo.DataAccesLayer.Abstract;
using _MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanyDal;

        public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
        {
            _cargoCompanyDal = cargoCompanyDal;
        }
        public void TInsert(CargoCompany entity)
        {
            _cargoCompanyDal.Insert(entity);
        }
        public void TUpdate(CargoCompany entity)
        {
            _cargoCompanyDal.Update(entity);
        }
        public void TDelete(int id)
        {
            _cargoCompanyDal.Delete(id);
        }
        public CargoCompany TBetById(int id)
        {
           return _cargoCompanyDal.GetById(id);
        }
        public List<CargoCompany> TGetAll()
        {
            return _cargoCompanyDal.GetAll();
        }
    }
}
