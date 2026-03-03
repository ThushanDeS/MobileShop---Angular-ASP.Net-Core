using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileShopERP.API.Models
{
    public class SaleItem
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int SaleId { get; set; }
        
        [Required]
        public int ProductId { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        
        [StringLength(50)]
        public string IMEINumber { get; set; } = null!; // For mobile phones
        
        // Navigation properties
        [ForeignKey("SaleId")]
        public Sale Sale { get; set; } = null!;
        
        [ForeignKey("ProductId")]
        public Product Product { get; set; } = null!;
    }
}