using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileShopERP.API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = null!;
        
        [Required]
        [StringLength(100)]
        public string Brand { get; set; } = null!;
        
        [Required]
        [StringLength(100)]
        public string Model { get; set; } = null!;
        
        [StringLength(50)]
        public string IMEI { get; set; } = null!;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal SellingPrice { get; set; }
        
        public int StockQuantity { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedAt { get; set; }
        
        public bool IsActive { get; set; } = true;
    }
}