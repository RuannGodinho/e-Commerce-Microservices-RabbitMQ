
using GeekCommerce.CartAPI.Model;
using GeekCommerce.OrderAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekCommerce.CartAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextOptions<MySqlContext> _context;

        public OrderRepository(DbContextOptions<MySqlContext> context)
        {
            _context = context;
        }

        public async Task<bool> AddOrder(OrderHeader header)
        {
            if(header == null) return false;
            await using var _db = new MySqlContext(_context);
            _db.Header.Add(header);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task UpdateOrderPaymentStatus(long orderHeaderId, bool status)
        {
            await using var _db = new MySqlContext(_context);
            var header = await _db.Header.FirstOrDefaultAsync(o => o.Id == orderHeaderId);
            if (header == null)
            {
                header.PaymentStatus = status;
                await _db.SaveChangesAsync();
            }
        }
    }
}
