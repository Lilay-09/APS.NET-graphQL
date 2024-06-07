using Microsoft.AspNetCore.Mvc;
using sync.Core.Items;

namespace sync.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController:ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        //[HttpGet]
        //public async Task<IActionResult> GetProduct()
        //{
        //    var data = await _categoryService.GetCategories();
        //    return new JsonResult(data);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetProductById(Guid id)
        //{

        //}
        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            var list = await _categoryService.GetCategories();
            return new JsonResult(list);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var list = await _categoryService.GetCategory(id);
            return new JsonResult(list);
        }
    }
}
