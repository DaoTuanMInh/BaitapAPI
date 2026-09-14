using WebApplication1.DTOs;
using WebApplication1.Model; 

namespace WebApplication1.Services.Interfaces
{
    public interface IOrderService
    {
        int ProductsSold();
        List<StockStatusDto> StockStatus();
        List<OrderDetailDto> Orderdetails();
        List<MonthlyRevenueDto> ReportMonth();
    }
}
