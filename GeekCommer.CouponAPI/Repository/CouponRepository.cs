using AutoMapper;
using GeekCommerce.CouponAPI.Data.ValueObjects;
using GeekCommerce.CouponAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekCommer.CouponAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public CouponRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CouponVO> GetCouponByCouponCode(string couponCode)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(_ => _.CouponCode == couponCode);

            return _mapper.Map<CouponVO>(coupon);
        }
    }
}
