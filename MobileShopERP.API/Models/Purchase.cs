using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileShopERP.API.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string PurchaseOrderNumber { get; set; } = null!;
        
        [Required]
        public int SupplierId { get; set; }
        
        public int UserId { get; set; } // User who created purchase
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal PaidAmount { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal DueAmount { get; set; }
        
        [StringLength(500)]
        public string Notes { get; set; } = null!;
        
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        
        public DateTime? ReceivedDate { get; set; }
        
        [StringLength(50)]
        public string Status { get; set; } = null!; // Pending, Completed, Cancelled
        
        // Navigation properties
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; } = null!;
        
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
        
        public ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
    }
}