﻿using _MultiShop.Cargo.DataAccesLayer.Abstract;
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
    public class EfCargoOperationDal : GenericRepository<CargoOperation>, ICargoOperationDal
    {
        public EfCargoOperationDal(CargoContext context) : base(context)
        {
        }
    }
}
