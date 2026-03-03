using Microsoft.EntityFrameworkCore;
using MobileShopERP.API.Data;
using MobileShopERP.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShopERP.API.Repositories
{

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsWithLowStock(int threshold)
        {
            return await _dbSet
                .Where(p => p.StockQuantity <= threshold && p.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchProducts(string searchTerm)
        {
            searchTerm = searchTerm.ToLower();
            return await _dbSet
                .Where(p => p.IsActive && (
                    p.Name.ToLower().Contains(searchTerm) ||
                    p.Brand.ToLower().Contains(searchTerm) ||
                    p.Model.ToLower().Contains(searchTerm) ||
                    p.IMEI.ToLower().Contains(searchTerm)))
                .ToListAsync();
        }

        public async Task<bool> IsImeiUnique(string imei)
        {
            if (string.IsNullOrEmpty(imei))
                return true;

            return !await _dbSet.AnyAsync(p => p.IMEI == imei);
        }

        public async Task<Product> GetProductByImei(string imei)
        {
            var product = await _dbSet
                .FirstOrDefaultAsync(p => p.IMEI == imei && p.IsActive);
            return product!;
        }

        // **No need to redeclare SaveChangesAsync here**
        // Repository<Product> already has it via IRepository<Product>
    }
}