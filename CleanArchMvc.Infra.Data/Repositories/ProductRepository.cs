using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetProductAndCategory(int? id)
        {
            return await _context.Products.Include(p => p.Category).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> GetProductById(int? id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(int? categoryId)
        {
            return await _context.Products.Include(p => p.Category).Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<Product> Remove(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product category)
        {
            _context.Products.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
