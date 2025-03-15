using _MultiShop.Discount.Context;
using _MultiShop.Discount.Dtos;
using Dapper;

namespace _MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }
        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            string query = "select * from Coupons";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }
        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            string query = "select * from Coupons where CouponID=@p1";
            var parameters = new DynamicParameters();
            parameters.Add("@p1", id);

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query, parameters);
            }
        }
        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons(code,rate,IsActive,ValidDate) values (@p1,@p2,@p3,@p4)";
            var parameters = new DynamicParameters();
            parameters.Add("@p1", createCouponDto.Code);
            parameters.Add("@p2", createCouponDto.Rate);
            parameters.Add("@p3", createCouponDto.IsActive);
            parameters.Add("@p4", createCouponDto.ValidDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "update coupons set code=@p1, rate=@p2, IsActive=@p3, ValidDate=@p4 where CouponId=@p5";
            var parameters = new DynamicParameters();
            parameters.Add("@p1", updateCouponDto.Code);
            parameters.Add("@p2", updateCouponDto.Rate);
            parameters.Add("@p3", updateCouponDto.IsActive);
            parameters.Add("@p4", updateCouponDto.ValidDate);
            parameters.Add("@p5", updateCouponDto.CouponID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteCouponAsync(int id)
        {
            string query = "Delete From Coupons where CouponID=@p1";
            var parameters = new DynamicParameters();
            parameters.Add("@p1", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<ResultCouponDto> GetCodeDetailByCode(string code)
        {
            string query = "select * from Coupons where code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultCouponDto>(query, parameters);
                return values;
            }
        }

        public int GetDiscountCouponRateAsync(string code)
        {
            string query = "select rate from Coupons";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query,parameters);
                return values;
            }
        }
    }
}
