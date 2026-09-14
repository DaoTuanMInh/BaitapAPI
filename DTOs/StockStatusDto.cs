using WebApplication1.Model;

namespace WebApplication1.DTOs
{
    public class StockStatusDto
    {
        public string Status { get; set; }
        public List<Product> Products { get; set; }
    }
}
