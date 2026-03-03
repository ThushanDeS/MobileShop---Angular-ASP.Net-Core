using System;
using System.ComponentModel.DataAnnotations;

namespace MobileShopERP.API.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string IMEI { get; set; } = null!;
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateProductDto
    {
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

        [Required]
        [Range(0, double.MaxValue)]
        public decimal PurchasePrice { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal SellingPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }
    }

    public class UpdateProductDto
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Brand { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Model { get; set; } = null!;

        [Required]
        [Range(0, double.MaxValue)]
        public decimal SellingPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }
    }
}