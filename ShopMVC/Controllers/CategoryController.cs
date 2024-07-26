using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopDTO;
using ShopService;

namespace ShopMVC.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }


        // GET: CategoryController
        public async Task<ActionResult> Index()
        {
            var category = await categoryService.GetAll();
            return View(category);
        }
    

        // GET: CategoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var category = await categoryService.GetById(id);
            if(category == null)
            {
                return NotFound();
            } 
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoryDTO category)
        {
            try
            {
                await categoryService.Create(category);
                SetAlert("Tao thanh cong", "success");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(category);
            }
        }

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var category = await categoryService.GetById(id);
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CategoryDTO category)
        {
            try
            {
                await categoryService.Update(category);
                SetAlert("Sua thanh cong", "success");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var category = await categoryService.GetById(id);
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirm(int id)
        {
            try
            {
                await categoryService.Delete(id);
                SetAlert("Xoa thanh cong", "success");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
