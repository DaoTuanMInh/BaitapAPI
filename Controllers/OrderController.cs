using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Model;
using WebApplication1.Services.Implementations;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly IOrderService _quantity;
        public OrderController(IOrderService quantityservice)
        {
            _quantity = quantityservice;
        }
        // bai 7
        [HttpGet("total-completed-quantity")]
        public IActionResult ProductsSold()
        {
            var ans7 = _quantity.ProductsSold();
            return Ok(ans7);
        }
        //bai 9
        [HttpGet("stock-status")]
        public List<StockStatusDto> StockStatus()
        {
            var ans9 = _quantity.StockStatus();
            return ans9;
        }
        //bai 10
        [HttpGet("details")]
        public List<OrderDetailDto> Orderdetails()
        {
            var ans10 = _quantity.Orderdetails();
            return ans10;
        }
        //bai 13
        [HttpGet("revenue-by-month")]
        public List<MonthlyRevenueDto> ReportMonth()
        {
            var ans13 = _quantity.ReportMonth();
            return ans13;
        }
    }

}
