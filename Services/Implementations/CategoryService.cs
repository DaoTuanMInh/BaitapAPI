using ProductApi.Data;
using WebApplication1.DTOs;
using WebApplication1.Model;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations
{
    public class CategoryService : ICategoryService
    {

        //bai 8
        public List<Report> ListReport()
        {
            List<Report> ans8 = SeedData.Products.GroupBy(p => p.Id)
                                                   .Select(p => new Report()
                                                   {
                                                       CateId = p.Key,
                                                       TotalStock = p.Sum(p => p.Stock),
                                                       MaxPrice = p.Max(P => P.Price),
                                                       MinPrice = p.Min(p => p.Price)
                                                   })
                                                   .ToList();
            return ans8;                                                                                          
                                                   
        }
        //Kết nối Order "Completed" với Product, sau đó nhóm theo CategoryId.
        //Kết quả nhóm phải có CategoryId, tổng tiền bán được của ngành đó,
        //và một danh sách con chứa chi tiết các đơn hàng thuộc ngành đó.
        // bai 15
        public List<CategoryRevenueDto> CategoryRevenue()
        {
            List<CategoryRevenueDto> ans15 = SeedData.Orders
                .Where(p => p.Status == "Completed")
                .Join(SeedData.Products,
                OrdersPr => OrdersPr.ProductId,
                ProductId => ProductId.Id,
                 (OrdersPr, ProductId) => new 
                 {
                     CategoryId = OrdersPr,
                     ProductId = ProductId,
                 })
                .GroupBy(p => p.ProductId.CategoryId)
                .Select(p => new CategoryRevenueDto()
                {
                    CategoryId = p.Key,
                    TotalRevenue = p.Sum(p => p.CategoryId.Quantity * p.ProductId.Price),
                    ListOrder = p.Select(p => new OrderDetailDto()
                    {
                        OrderId = p.CategoryId.Id,
                        ProductName = p.ProductId.Name,
                        Price = p.ProductId.Price,
                        Quantity = p.CategoryId.Quantity,
                        TotalAmount = p.ProductId.Price * p.CategoryId.Quantity
                    })
                    .ToList()
                })
                .ToList();

            return ans15;

        }
    }
}
