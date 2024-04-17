using Cloud_Based_Inventory_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Cloud_Based_Inventory_Management_System.Contexts
{
    public class InventoryContext:DbContext
    {

        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }



        public DbSet<InventoryModel> Inventories { get; set; }



    }
}
