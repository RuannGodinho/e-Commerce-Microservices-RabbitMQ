using Microsoft.EntityFrameworkCore;

namespace GeekCommerce.Email.Model
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
        public DbSet<EmailLog> Emails { get; set; }

    }
}
