namespace WebApplication1.DTOs
{
    public class CategoryRevenueDto
    {
        public int CategoryId { get; set; }
        public double TotalRevenue { get; set; }
        public List<OrderDetailDto> ListOrder { get; set; }
    }
}
