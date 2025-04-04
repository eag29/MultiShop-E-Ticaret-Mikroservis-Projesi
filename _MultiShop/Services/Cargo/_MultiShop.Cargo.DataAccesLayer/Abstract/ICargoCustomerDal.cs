﻿using _MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MultiShop.Cargo.DataAccesLayer.Abstract
{
    public interface ICargoCustomerDal: IGenericDal<CargoCustomer>
    {
        CargoCustomer GetCargoCustomerById(string id);
    }
}
