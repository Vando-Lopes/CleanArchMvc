using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int? id);
        Task<IEnumerable<Product>> GetProductsByCategory(int? categoryId);

        Task<Product> Create(Product category);
        Task<Product> Update(Product category);
        Task<Product> Remove(int id);
    }
}
