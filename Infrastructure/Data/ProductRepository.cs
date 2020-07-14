using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _contex;
        public ProductRepository(StoreContext contex)
        {
            _contex = contex;
        }


        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _contex.Products
                .Include(x => x.ProductType)
                .Include(x => x.ProductBrand)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _contex.Products
                .Include(x => x.ProductType)
                .Include(x => x.ProductBrand)
                .ToListAsync();
        }
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _contex.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypessAsync()
        {
            return await _contex.ProductTypes.ToListAsync();

        }
    }
}