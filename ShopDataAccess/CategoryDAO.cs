using Microsoft.EntityFrameworkCore;
using ShopBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDataAccess
{
    public class CategoryDAO : SingletonBase<CategoryDAO>
    {
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<Category> GetById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);

            return category;
        }
        public async Task Create(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Category category)
        {
            var existingItem = await GetById(category.CategoryId);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(category);
            }


            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var existingItem = await GetById(id);
            if (existingItem != null)
            {
                _context.Categories.Remove(existingItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}