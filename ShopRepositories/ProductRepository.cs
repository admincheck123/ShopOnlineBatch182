using ShopBussinessObject;
using ShopDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task<IEnumerable<Product>> GetProducts() => await ProductDAO.Instance.GetProductsAsync();
        public async Task<Product> GetById(int id) => await ProductDAO.Instance.GetById(id);
        public async Task Create(Product product) => await ProductDAO.Instance.Create(product);
        public async Task Update(Product product) => await ProductDAO.Instance.Update(product);
        public async Task Delete(int id) => await ProductDAO.Instance.Delete(id);
    }
}