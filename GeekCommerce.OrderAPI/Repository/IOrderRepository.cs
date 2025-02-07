using GeekCommerce.OrderAPI.Model;

namespace GeekCommerce.CartAPI.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader header);
        Task UpdateOrderPaymentStatus(long orderHeaderId, bool paid);

    }
}
