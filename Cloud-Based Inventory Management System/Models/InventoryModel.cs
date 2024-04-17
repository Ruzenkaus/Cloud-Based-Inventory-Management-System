using System.ComponentModel.DataAnnotations;

namespace Cloud_Based_Inventory_Management_System.Models
{
    public class InventoryModel
    {
        [Key]
        public int InventoryId { get; set; }
        [Required]
        public string Owner { get; set; } 
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;


    }
}
