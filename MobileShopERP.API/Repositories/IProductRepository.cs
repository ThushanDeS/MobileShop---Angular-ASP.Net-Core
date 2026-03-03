using MobileShopERP.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileShopERP.API.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsWithLowStock(int threshold);
        Task<IEnumerable<Product>> SearchProducts(string searchTerm);
        Task<bool> IsImeiUnique(string imei);
        Task<Product> GetProductByImei(string imei);
    }
}