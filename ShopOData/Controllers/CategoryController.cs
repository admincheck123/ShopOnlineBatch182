using Microsoft.AspNetCore.Mvc;
using ShopBussinessObject;
using ShopRepositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopOData.Controllers
{
    [Route("odata")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryReposiory categoryReposiory;

        public CategoryController()
        {
            categoryReposiory = new CategoryRepository();
        }
        // GET: api/<CategoryController>
        [HttpGet("[controller]")]
        public async Task<IEnumerable<Category>> Get()
        {
            var category = await categoryReposiory.GetCategories();
            return category;
        }

        // GET api/<CategoryController>/5
        [HttpGet("[controller]({id})")]
        public async Task<Category> Get(int id)
        {
            var category = await categoryReposiory.GetById(id);
            return category;
        }

        // POST api/<CategoryController>
        [HttpPost("[controller]")]
        public async Task<ActionResult> Post([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await categoryReposiory.Create(category);
            return Ok(category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("[controller]({id})")]
        public async Task<ActionResult> Put(int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exist = await categoryReposiory.GetById(id);
            if (exist == null)
            {
                return NotFound();
            }
            category.CategoryId = id;
            await categoryReposiory.Update(category);
            return Ok("Update success!\n");
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("[controller]({id})")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await categoryReposiory.GetById(id);
            if (exist == null)
            {
                return NotFound();
            }
            await categoryReposiory.Delete(id);
            return Ok("Delete success\n");
        }
    }
}