using ServiceAPI.v1.Repositories;

namespace ServiceAPI.UnitOfWorks
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IShopRepository ShopRepository { get; }
        IProductRepository ProductRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
