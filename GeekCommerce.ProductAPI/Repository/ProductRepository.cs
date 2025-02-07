using AutoMapper;
using GeekCommerce.ProductAPI.Data.ValueObjects;
using GeekCommerce.ProductAPI.Model;
using GeekCommerce.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekCommerce.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public ProductRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductVo>> FindAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVo>>(products);
        }

        public async Task<ProductVo> FindById(long id)
        {
            Product product = await _context.Products.Where(_ => _.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductVo>(product);
        }

        public async Task<ProductVo> Create(ProductVo vo)
        {
            Product product = _mapper.Map<Product>(vo);
            _context.Products.Add(product);
            _context.SaveChangesAsync();

            return _mapper.Map<ProductVo>(product);
        }
        public async Task<ProductVo> Update(ProductVo vo)
        {
            Product product = _mapper.Map<Product>(vo);
            _context.Products.Update(product);
            _context.SaveChangesAsync();

            return _mapper.Map<ProductVo>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Product product = await _context.Products.Where(_ => _.Id == id).FirstOrDefaultAsync();
                if(product == null)
                    return false;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


    }
}
