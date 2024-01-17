using ServiceAPI.Common;
using ServiceAPI.v1.Repositories;

namespace ServiceAPI.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _dbContext;
        private ICustomerRepository _customerRepository;
        private IShopRepository _shopRepository;
        private IProductRepository _productRepository;
        private IOrderDetailRepository _orderDetailRepository;

        public UnitOfWork(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICustomerRepository CustomerRepository
        {
            get { return _customerRepository = _customerRepository ?? new CustomerRepository(_dbContext); }
        }

        public IShopRepository ShopRepository
        {
            get { return _shopRepository = _shopRepository ?? new ShopRepository(_dbContext); }
        }

        public IProductRepository ProductRepository
        {
            get { return _productRepository = _productRepository ?? new ProductRepository(_dbContext); }
        }

        public IOrderDetailRepository OrderDetailRepository
        {
            get { return _orderDetailRepository = _orderDetailRepository ?? new OrderDetailRepository(_dbContext); }
        }

        public void Commit()
            => _dbContext.SaveChanges();

        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();

        public void Rollback()
            => _dbContext.Dispose();

        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
