using ShopBussinessObject;
using ShopDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepositories
{
    public class CategoryRepository : ICategoryReposiory
    {
        public async Task<IEnumerable<Category>> GetCategories() => await CategoryDAO.Instance.GetCategoriesAsync();
        public async Task<Category> GetById(int id) => await CategoryDAO.Instance.GetById(id);
        public async Task Create(Category category) => await CategoryDAO.Instance.Create(category);
        public async Task Update(Category category) => await CategoryDAO.Instance.Update(category);
        public async Task Delete(int id) => await CategoryDAO.Instance.Delete(id);




    }
}