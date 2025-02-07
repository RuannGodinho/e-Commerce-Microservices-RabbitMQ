using GeekCommerce.CartAPI.Data.ValueObjects;

namespace GeekCommerce.CartAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCouponByCouponCode(string couponCode, string token);
    }
}
