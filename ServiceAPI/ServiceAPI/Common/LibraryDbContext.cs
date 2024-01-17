using Microsoft.EntityFrameworkCore;
using ServiceAPI.v1.Models;

namespace ServiceAPI.Common
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<CustomerDto> Customer { get; set; }

        public DbSet<OrderDetailDto> OrderDetail { get; set; }

        public DbSet<ProductDto> Product { get; set; }

        public DbSet<ShopDto> Shop { get; set; }
    }
}
