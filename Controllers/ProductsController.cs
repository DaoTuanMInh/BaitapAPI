using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Data;
using WebApplication1.DTOs;
using WebApplication1.Model;
using WebApplication1.Services.Implementations;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly IProductService _productservice;

        public ProductsController(IProductService productservice)
        {
            _productservice = productservice;
        }
        // bai 1
        [HttpGet("available")]
        public List<Product> GetAvailableProducts()
        {
            var ans1 = _productservice.GetAvailableProducts();
            return ans1;
        }
        //bai 2 
        [HttpGet("sorted")]
        public List<Product> GetSortedProducts()
        {
            var ans2 = _productservice.GetSortedProducts();
            return ans2;
        }
        //bai 3
        [HttpGet("paging")]
        public List<Product> Pagination(int pageNumber, int pageSize)
        {
            var ans2 = _productservice.Pagination(pageNumber,pageSize);
            return ans2;
        }
        //bai 4
        [HttpGet("{inputId}")]
        public Product Search(int inputId)
        {
            var ans3 = _productservice.Search(inputId);
            return ans3;
        }
        //bai 5
        [HttpGet("total-inventory-value")]
        public IActionResult TotalPrice()
        {
            var ans5 = _productservice.TotalPrice();
            return Ok(ans5);
        }
        //bai 6
        [HttpGet("most-expensive-available")]
        public Product MaxPrice()
        {
            var ans6 = _productservice.MaxPrice();
            return ans6;
        }        
        //bai 11
        [HttpGet("CategoryWithProductsDto")]
        public List<CategoryWithProductsDto> CategoryStatistics()
        {
            var ans11 = _productservice.CategoryStatistics();
            return ans11;
        }
        //bai 12
        [HttpGet("unsold")]
        public List<Product> UnsoldProducts()
        {
            var ans12 = _productservice.UnsoldProducts();
            return ans12;
        }
        //Bai 14
        [HttpGet("top-3-best-sellers")]
        public List<TopProductDto> TopProduct()
        {
            var ans14 = _productservice.TopProduct();
            return ans14;
        }
    }
}
