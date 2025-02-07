using GeekCommerce.CouponAPI.Data.ValueObjects;

namespace GeekCommer.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCouponByCouponCode(string couponCode);
    }
}
