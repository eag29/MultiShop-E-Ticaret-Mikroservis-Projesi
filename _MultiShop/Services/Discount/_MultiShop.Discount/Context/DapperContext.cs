using _MultiShop.Discount.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace _MultiShop.Discount.Context
{
    public class DapperContext: DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Tabloyu veri tabanın yansıtmak için kullanılır.

            optionsBuilder.UseSqlServer("Server=DESKTOP-TMVO8N4\\SQLEXPRESS; initial Catalog=MultiShopDiscountVt; integrated Security=true");
        }
        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
