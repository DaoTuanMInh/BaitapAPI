using ProductApi.Data;
using WebApplication1.DTOs;
using WebApplication1.Model;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations
{
    public class OrderService : IOrderService
    {
        // bai 7
        public int ProductsSold()
        {
            int ans7 = SeedData.Orders.Where(p => p.Status == "Completed")
                                        .Sum(p => p.Quantity);
            return ans7;
        }
        //bai 9
        public List<StockStatusDto> StockStatus()
        {
            List<StockStatusDto> ans9 = SeedData.Products.GroupBy(p => p.Stock > 0? "Con hang": "Het hang")
                                                    .Select(p => new StockStatusDto()
                                                    {
                                                       Status = p.Key,
                                                       Products = p.Select(o => new Product()
                                                       {
                                                           Id = o.Id,
                                                           Name = o.Name,
                                                           Price = o.Price,
                                                           Stock = o.Stock,
                                                           CategoryId = o.CategoryId

                                                       })
                                                       .ToList()

                                                    })
                                                    .ToList();

            return ans9;
        }
        //bai 10
        public List<OrderDetailDto> Orderdetails()
        {
            List<OrderDetailDto> ans10 = SeedData.Orders.Where(p => p.Status == "Completed")
                                                           .Join(SeedData.Products,
                                                            OrdersPr => OrdersPr.ProductId,
                                                            ProductId => ProductId.Id,
                                                            (OrdersPr, ProductId) => new OrderDetailDto
                                                            {
                                                                OrderId = OrdersPr.Id,
                                                                ProductName = ProductId.Name,
                                                                Quantity = OrdersPr.Quantity,
                                                                Price = ProductId.Price,
                                                                TotalAmount =OrdersPr.Quantity * ProductId.Price

                                                            })
                                                           .ToList();
            return ans10;
        }
        //bai 13
        public List<MonthlyRevenueDto> ReportMonth()
        {
            List<MonthlyRevenueDto> ans13 = SeedData.Orders.Where(p => p.Status == "Completed")
                                                           .GroupBy (p => p.OrderDate.Month)
                                                            .Select(p => new MonthlyRevenueDto()
                                                            {
                                                                Month = p.Key,
                                                                OrderCount = p.Count(),
                                                                TotalQuantitySold = p.Sum(p => p.Quantity)
                                                            })
                                                            .ToList();
            return ans13;
        }
    }
}
