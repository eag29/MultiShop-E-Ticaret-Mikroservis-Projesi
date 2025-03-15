using _MultiShop.Cargo.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MultiShop.Cargo.DataAccesLayer.Concrete
{
    public class CargoContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1441; initial Catalog=CargoVt; User=sa; Password=EmirAliGirgin_29");
        }

        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<CargoCustomer> CargoCustomers { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoOperation> CargoOperations { get; set; }
    }
}
