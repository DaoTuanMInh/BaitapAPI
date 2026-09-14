using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        //bai8
        [HttpGet("ategory - report")]
        public List<Report> ListReport()
        {
            var ans8 = _categoryService.ListReport();
            return ans8;
        }
        [HttpGet("revenue")]
        public List<CategoryRevenueDto> CategoryRevenue()
        {
            var ans15 = _categoryService.CategoryRevenue();
            return ans15;
        }

    }
}
