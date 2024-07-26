using ShopBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepositories
{
    public interface ICategoryReposiory
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetById(int id);
        Task Create(Category category);
        Task Update(Category category);
        Task Delete(int id);
    }
}