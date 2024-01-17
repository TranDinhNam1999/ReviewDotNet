using Microsoft.EntityFrameworkCore;
using ServiceAPI.Common;
using ServiceAPI.v1.Models;

namespace ServiceAPI.v1.Repositories
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetailDto>
    {
        public Task<IEnumerable<OrderDetailDto>> GetOrderDetailListAsync();
    }

    public class OrderDetailRepository : GenericRepository<OrderDetailDto>, IOrderDetailRepository
    {
        public OrderDetailRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<OrderDetailDto>> GetOrderDetailListAsync()
        {
            var query = from orderDetail in _dbContext.OrderDetail
                        join customer in _dbContext.Customer on orderDetail.CustomerId equals customer.Id
                        join shop in _dbContext.Shop on orderDetail.ShopId equals shop.Id
                        join product in _dbContext.Product on orderDetail.ProductId equals product.Id
                        select new OrderDetailDto
                        {
                            customerName = customer.FullName,
                            customerEmail = customer.Email,
                            shopName = shop.Name,
                            shopLocation = shop.Location,
                            productName = product.Name,
                            CustomerId = product.Id,
                            ShopId = shop.Id,
                            ProductId = product.Id,
                        };


            return await query.ToListAsync();
        }
    }
}
