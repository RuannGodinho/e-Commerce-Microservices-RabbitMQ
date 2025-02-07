using AutoMapper;
using GeekCommerce.CouponAPI.Data.ValueObjects;
using GeekCommerce.CouponAPI.Model;

namespace GeekCommerce.couponAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponVO, Coupon>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
