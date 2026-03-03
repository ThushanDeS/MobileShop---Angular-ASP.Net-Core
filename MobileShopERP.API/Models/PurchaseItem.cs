using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileShopERP.API.Models
{
    public class PurchaseItem
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int PurchaseId { get; set; }
        
        [Required]
        public int ProductId { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        
        [StringLength(50)]
        public string IMEINumber { get; set; } = null!;
        
        // Navigation properties
        [ForeignKey("PurchaseId")]
        public Purchase Purchase { get; set; } = null!;
        
        [ForeignKey("ProductId")]
        public Product Product { get; set; } = null!;
    }
}