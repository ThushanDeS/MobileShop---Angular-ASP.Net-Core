using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MobileShopERP.API.DTOs
{
    public class SaleDto
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; } = null!;
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CashierName { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public DateTime SaleDate { get; set; }
        public List<SaleItemDto> Items { get; set; } = new();
    }

    public class SaleItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public string IMEINumber { get; set; } = null!;
    }

    public class CreateSaleDto
    {
        public int? CustomerId { get; set; }

        [Required]
        public decimal DiscountAmount { get; set; } = 0;

        [Required]
        public decimal TaxAmount { get; set; } = 0;

        [Required]
        public decimal PaidAmount { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; } = null!;

        [StringLength(500)]
        public string Notes { get; set; } = null!;

        [Required]
        [MinLength(1)]
        public List<CreateSaleItemDto> Items { get; set; } = new();
    }

    public class CreateSaleItemDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public string IMEINumber { get; set; } = null!;
    }
}