using AutoMapper;
using MobileShopERP.API.DTOs;
using MobileShopERP.API.Models;
using MobileShopERP.API.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileShopERP.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {id} not found");
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            // Check if IMEI is unique
            if (!string.IsNullOrEmpty(createProductDto.IMEI))
            {
                var isUnique = await _productRepository.IsImeiUnique(createProductDto.IMEI);
                if (!isUnique)
                    throw new InvalidOperationException("IMEI number already exists");
            }

            var product = _mapper.Map<Product>(createProductDto);
            product.CreatedAt = DateTime.Now;
            product.IsActive = true;

            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {id} not found");

            _mapper.Map(updateProductDto, product);
            product.UpdatedAt = DateTime.Now;

            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return false;

            // Soft delete
            product.IsActive = false;
            product.UpdatedAt = DateTime.Now;

            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ProductDto>> GetLowStockProductsAsync(int threshold)
        {
            var products = await _productRepository.GetProductsWithLowStock(threshold);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<ProductDto>> SearchProductsAsync(string searchTerm)
        {
            var products = await _productRepository.SearchProducts(searchTerm);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<bool> UpdateStockAsync(int productId, int quantity)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found");

            if (product.StockQuantity + quantity < 0)
                throw new InvalidOperationException("Insufficient stock");

            product.StockQuantity += quantity;
            product.UpdatedAt = DateTime.Now;

            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();

            return true;
        }
    }
}
