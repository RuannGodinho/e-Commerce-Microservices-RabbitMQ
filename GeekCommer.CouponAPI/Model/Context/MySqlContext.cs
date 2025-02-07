using GeekCommerce.CouponAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekCommerce.CouponAPI.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<Coupon> Coupons { get; set; }


    }
}
