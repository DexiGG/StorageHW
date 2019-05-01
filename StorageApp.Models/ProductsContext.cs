using System.Data.Entity;

namespace StorageApp.Models
{
    public class ProductsContext : DbContext
    {
        public ProductsContext() : base ("appConnection")
        {}
        
        public DbSet<Product> Products { get; set; }
    }
}
