using Microsoft.EntityFrameworkCore;
using ShopBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDataAccess
{
    public class ProductDAO : SingletonBase<ProductDAO>
    {
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.Include(c => c.Category).ToListAsync();
        }
        public async Task<Product> GetById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c => c.ProductId == id);

            return product;
        }
        public async Task Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Product product)
        {
            var existingItem = await GetById(product.ProductId);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(product);
            }
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var existingItem = await GetById(id);
            if (existingItem != null)
            {
                _context.Products.Remove(existingItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}