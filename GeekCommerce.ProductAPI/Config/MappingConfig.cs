using AutoMapper;
using GeekCommerce.ProductAPI.Data.ValueObjects;
using GeekCommerce.ProductAPI.Model;

namespace GeekCommerce.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVo, Product>();
                config.CreateMap<Product, ProductVo>();
            });
            return mappingConfig;
        }
    }
}
