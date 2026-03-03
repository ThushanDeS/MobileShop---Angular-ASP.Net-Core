// DTOs/SupplierDto.cs
namespace MobileShopERP.API.DTOs
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ContactPerson { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string AlternatePhone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string GSTNumber { get; set; } = null!;
    }

    public class CreateSupplierDto
    {
        public string Name { get; set; } = null!;
        public string ContactPerson { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string AlternatePhone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string GSTNumber { get; set; } = null!;
    }

    public class UpdateSupplierDto : CreateSupplierDto { }
}