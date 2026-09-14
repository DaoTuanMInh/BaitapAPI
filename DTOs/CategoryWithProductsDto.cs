using WebApplication1.Model;

namespace WebApplication1.DTOs
{
    public class CategoryWithProductsDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    } 
}
