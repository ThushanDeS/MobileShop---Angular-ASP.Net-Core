using System.ComponentModel.DataAnnotations;

namespace MobileShopERP.API.DTOs
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }

    public class RegisterDto
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        [Phone]
        public string Phone { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = null!;
    }

    public class LoginResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Token { get; set; } = null!;
        public DateTime Expiration { get; set; }
    }
}