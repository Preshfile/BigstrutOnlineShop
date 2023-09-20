using Microsoft.EntityFrameworkCore;
using BigstrutOnlineShop.Api.Data;
using BigstrutOnlineShop.Api.Entities;
using BigstrutOnlineShop.Api.Repositories.Contracts;

namespace BigstrutOnlineShop.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BigstrutOnlineShopDbContext bigstrutOnlineShopDbContext;

        public ProductRepository(BigstrutOnlineShopDbContext bigstrutOnlineShopDbContext)
        {
            this.bigstrutOnlineShopDbContext = bigstrutOnlineShopDbContext;
        }

        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await this.bigstrutOnlineShopDbContext.ProductCategories.ToListAsync();
            return categories ?? Enumerable.Empty<ProductCategory>();
        }

        public async Task<ProductCategory> GetCategory(int id)
        {
            var category = await bigstrutOnlineShopDbContext.ProductCategories
                .SingleOrDefaultAsync(c => c.Id == id)
                ?? throw new NotFoundException($"Product category with ID {id} not found.");

            return category;
        }

        public async Task<Product> GetItem(int id)
        {
            var product = await bigstrutOnlineShopDbContext.Products
                .FindAsync(id)
                ?? throw new NotFoundException($"Product with ID {id} not found.");
                return product;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await this.bigstrutOnlineShopDbContext.Products.ToListAsync();
            return products ?? Enumerable.Empty<Product>();
        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
