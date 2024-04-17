using Cloud_Based_Inventory_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Cloud_Based_Inventory_Management_System.Contexts
{
    public class ProductContext : DbContext
    {

        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }



        public DbSet<ProductModel> Products { get; set; }

    }
}
