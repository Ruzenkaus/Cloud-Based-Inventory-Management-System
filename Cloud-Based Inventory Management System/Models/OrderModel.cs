using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cloud_Based_Inventory_Management_System.Models
{
    public class OrderModel
    {

        [Key]
        public int OrderId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string Status { get; set; } = string.Empty;  

    }
}
