using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ShopBussinessObject;

namespace ShopOData
{
    public class EDMModelBuilder
    {
        public static IEdmModel GetEDMModel()
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Product>("Products");
            modelBuilder.EntitySet<Category>("Categories");
            var product = modelBuilder.EntityType<Product>();
            product.HasRequired(p => p.Category, (product, category) => product.CategoryId == category.CategoryId);
            return modelBuilder.GetEdmModel();
        }
    }
}