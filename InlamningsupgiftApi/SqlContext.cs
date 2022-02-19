using InlamningsupgiftApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InlamningsupgiftApi
{
    public class SqlContext: DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<CustomerEntity> Customers { get; set; }
        public virtual DbSet<OrderEntity> Orders { get; set; }
        public virtual DbSet<CategoryEntity> Categories { get; set; }
        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<OrderedProductsEntity> OrderedProducts { get; set; }
    }
}
