using Microsoft.EntityFrameworkCore;
using ServiceAPI.Common;
using ServiceAPI.v1.Models;

namespace ServiceAPI.v1.Repositories
{
    public interface IShopRepository : IGenericRepository<CustomerDto>
    {
        public Task<IEnumerable<ShopDto>> GetShopListAsync();
        public Task<ShopDto> GetShopByIdAsync(Guid Id);
        public Task<ShopDto> AddShopAsync(ShopDto shopDto);
        public Task<int> DeleteShopAsync(Guid Id);
    }

    public class ShopRepository : GenericRepository<CustomerDto>, IShopRepository
    {
        public ShopRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ShopDto> AddShopAsync(ShopDto shopDto)
        {

            await _dbContext.Shop.AddAsync(shopDto);
            //await _dbContext.SaveChangesAsync();

            return shopDto;
        }

        public async Task<int> DeleteShopAsync(Guid Id)
        {
            var data = await _dbContext.Shop.FirstOrDefaultAsync(x => x.Id == Id);

            if (data != null)
            {
                _dbContext.Shop.Remove(data);
                return await _dbContext.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<ShopDto> GetShopByIdAsync(Guid Id)
        {
            return await _dbContext.Shop.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<ShopDto>> GetShopListAsync()
        {
            return await _dbContext.Shop.ToListAsync();
        }
    }
}
