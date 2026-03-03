using System;
using System.ComponentModel.DataAnnotations;

namespace MobileShopERP.API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Username { get; set; } = null!;
        
        [Required]
        public string PasswordHash { get; set; } = null!;
        
        [Required]
        [StringLength(50)]
        public string Role { get; set; } = null!; // Admin, Manager, Cashier
        
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = null!;
        
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; } = null!;
        
        [StringLength(20)]
        public string Phone { get; set; } = null!;
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public DateTime? LastLoginAt { get; set; }
    }
}