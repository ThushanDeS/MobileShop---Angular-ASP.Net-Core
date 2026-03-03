using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MobileShopERP.API.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = null!;
        
        [Required]
        [StringLength(20)]
        public string Phone { get; set; } = null!;
        
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; } = null!;
        
        [StringLength(300)]
        public string Address { get; set; } = null!;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedAt { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        // Navigation property
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}