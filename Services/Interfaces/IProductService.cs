using WebApplication1.DTOs;
using WebApplication1.Model;

namespace WebApplication1.Services.Interfaces

{
    public interface IProductService
    {
        //bai 1
        List<Product> GetAvailableProducts();
        //bai 2
        List<Product> GetSortedProducts();
        //bai 3
        List<Product> Pagination(int pageNumber, int pageSize);
        //bai 4
        Product Search(int id);
        //bai5
        double TotalPrice();
        //bai 6
        Product MaxPrice();
        //bai 11
        List<CategoryWithProductsDto> CategoryStatistics();
        //bai 12
        List<Product> UnsoldProducts();
        //bai 14
        List<TopProductDto> TopProduct();

    }
}
