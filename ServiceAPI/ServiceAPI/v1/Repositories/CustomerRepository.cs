using Microsoft.EntityFrameworkCore;
using ServiceAPI.Common;
using ServiceAPI.v1.Models;
using System.Linq.Expressions;

namespace ServiceAPI.v1.Repositories
{

    public interface ICustomerRepository : IGenericRepository<CustomerDto>
    {
        public Task<IEnumerable<CustomerDto>> GetCustomerListAsync();
        public Task<CustomerDto> GetCustomerByIdAsync(Guid Id);
        public Task<CustomerDto> AddCustomerAsync(CustomerDto Customer);
        public Task<int> DeleteCustomerAsync(Guid Id);
    }

    public class CustomerRepository : GenericRepository<CustomerDto>, ICustomerRepository
    {
        public CustomerRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<CustomerDto> AddCustomerAsync(CustomerDto Customer)
        {

            await _dbContext.Customer.AddAsync(Customer);
            //await _dbContext.SaveChangesAsync();

            return Customer;
        }

        public async Task<int> DeleteCustomerAsync(Guid Id)
        {
            var customer = await _dbContext.Customer.FirstOrDefaultAsync(x => x.Id == Id);

            if (customer != null)
            {
                _dbContext.Customer.Remove(customer);
                return await _dbContext.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(Guid Id)
        {
            var data = await _dbContext.Customer.FirstOrDefaultAsync(x => x.Id == Id);
            return data!;
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomerListAsync()
        {
            return await _dbContext.Customer.ToListAsync();
        }

    }
}
