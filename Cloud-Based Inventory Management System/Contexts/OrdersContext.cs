using Cloud_Based_Inventory_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Cloud_Based_Inventory_Management_System.Contexts
{
    public class OrdersContext : DbContext
    {


        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options) { }



        public DbSet<OrderModel> Orders { get; set; }

    }
}
