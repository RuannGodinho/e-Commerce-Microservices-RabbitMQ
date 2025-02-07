using GeekCommerce.OrderAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekCommerce.OrderAPI.Model
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<OrderDetail> Details { get; set; }
        public DbSet<OrderHeader> Header { get; set; }

    }
}
