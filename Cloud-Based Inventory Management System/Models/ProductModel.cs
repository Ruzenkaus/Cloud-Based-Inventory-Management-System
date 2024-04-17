using System.ComponentModel.DataAnnotations;

namespace Cloud_Based_Inventory_Management_System.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty ;
        [Required]
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

    }
}
