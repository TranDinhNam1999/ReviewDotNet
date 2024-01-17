using Microsoft.EntityFrameworkCore;
using ServiceAPI.Common;
using ServiceAPI.v1.Models;

namespace ServiceAPI.v1.Repositories
{
    public interface IProductRepository : IGenericRepository<ProductDto>
    {
        public Task<IEnumerable<ProductDto>> GetProductListAsync();
        public Task<ProductDto> GetProductByIdAsync(Guid Id);
        public Task<ProductDto> AddProductAsync(ProductDto data);
        public Task<int> DeleteProductAsync(Guid Id);
    }

    public class ProductRepository : GenericRepository<ProductDto>, IProductRepository
    {
        public ProductRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ProductDto> AddProductAsync(ProductDto data)
        {

            await _dbContext.Product.AddAsync(data);
            //await _dbContext.SaveChangesAsync();

            return data;
        }

        public async Task<int> DeleteProductAsync(Guid Id)
        {
            var data = await _dbContext.Product.FirstOrDefaultAsync(x => x.Id == Id);

            if (data != null)
            {
                _dbContext.Product.Remove(data);
                return await _dbContext.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid Id)
        {
            return await _dbContext.Product.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<ProductDto>> GetProductListAsync()
        {
            return await _dbContext.Product.ToListAsync();
        }
    }
}
