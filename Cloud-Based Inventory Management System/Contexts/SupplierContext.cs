using Cloud_Based_Inventory_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Cloud_Based_Inventory_Management_System.Contexts
{
    public class SupplierContext : DbContext
    {

        public SupplierContext(DbContextOptions<SupplierContext> options) : base(options) { }



        public DbSet<SupplierModel> Sppliers { get; set; }

    }
}
