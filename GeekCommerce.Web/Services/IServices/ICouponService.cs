using GeekCommerce.Web.Models;

namespace GeekCommerce.Web.Services.IServices
{
    public interface ICouponService
    {
        Task<CouponViewModel> GetCoupon(string couponCode, string token);

    }
}
