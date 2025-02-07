using GeekCommerce.ProductAPI.Data.ValueObjects;

namespace GeekCommerce.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVo>> FindAll();
        Task<ProductVo> FindById(long id);
        Task<ProductVo> Create(ProductVo vo);
        Task<ProductVo> Update(ProductVo vo);
        Task<bool> Delete(long id);
    }
}
