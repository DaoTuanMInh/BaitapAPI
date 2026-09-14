using WebApplication1.DTOs;
using WebApplication1.Model;

namespace WebApplication1.Services.Interfaces
{
    public interface ICategoryService
    {
        List<Report> ListReport();
        List<CategoryRevenueDto> CategoryRevenue();
    }
}
