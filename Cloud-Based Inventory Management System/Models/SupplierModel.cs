using System.ComponentModel.DataAnnotations;

namespace Cloud_Based_Inventory_Management_System.Models
{
    public class SupplierModel
    {

        [Key]
        public int SupplierId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string ContactInformation { get; set; } = string.Empty;

    }
}
