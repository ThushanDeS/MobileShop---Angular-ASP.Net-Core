using MobileShopERP.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileShopERP.API.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto);
        Task<ProductDto> UpdateProductAsync(int id, UpdateProductDto updateProductDto);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<ProductDto>> GetLowStockProductsAsync(int threshold);
        Task<IEnumerable<ProductDto>> SearchProductsAsync(string searchTerm);
        Task<bool> UpdateStockAsync(int productId, int quantity);
    }
}