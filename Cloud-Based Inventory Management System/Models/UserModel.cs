using System.ComponentModel.DataAnnotations;

namespace Cloud_Based_Inventory_Management_System.Models
{
    public class UserModel
    {

        [Key]
        public int Id { get; set; }


     
        public string Email { get; set; } = string.Empty;


        public string HashedPassword { get; set; } = string.Empty;


    
        public string Name { get; set; } = string.Empty;


        public string Role { get; set; } = "Client" ;


        public string Plan { get; set; } = "No plan";
    }
}
