using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MultiShop.Cargo.DataAccesLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        T GetById(int id);
        List<T> GetAll();
    }
}
