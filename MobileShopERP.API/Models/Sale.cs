using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileShopERP.API.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string InvoiceNumber { get; set; } = null!;
        
        public int? CustomerId { get; set; }
        
        public int UserId { get; set; } // Cashier/User who created sale
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountAmount { get; set; } = 0;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal TaxAmount { get; set; } = 0;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal GrandTotal { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal PaidAmount { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal DueAmount { get; set; }
        
        [StringLength(50)]
        public string PaymentMethod { get; set; } = null!; // Cash, Card, UPI, etc.
        
        [StringLength(500)]
        public string Notes { get; set; } = null!;
        
        public DateTime SaleDate { get; set; } = DateTime.Now;
        
        // Navigation properties
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; } = null!;
        
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
        
        public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
}