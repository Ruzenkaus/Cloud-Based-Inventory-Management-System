using Cloud_Based_Inventory_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Cloud_Based_Inventory_Management_System.Contexts
{
    public class UserContext : DbContext
    {

        public UserContext(DbContextOptions<UserContext> options): base(options) { }
        
        

        public DbSet<UserModel> Users { get; set; }

    }
}
