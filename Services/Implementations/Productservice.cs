using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http.HttpResults;
using ProductApi.Data;
using System.Diagnostics.CodeAnalysis;
using WebApplication1.DTOs;
using WebApplication1.Model;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations
{
    public class Productservice : IProductService
    {
        //bai 1
        public List<Product> GetAvailableProducts()
        {
            List<Product> ans1 = SeedData.Products.OrderBy(p => p.Stock > 0 )
                                                    .ToList();
            return ans1;
        }

        //bai 2
        public List<Product> GetSortedProducts()
        {
            List<Product> ans2 = SeedData.Products.OrderByDescending(p => p.Price)
                                                  .ThenBy(p => p.Name)
                                                   .ToList();
            return ans2;

        }

        //bai 3
        List<Product> IProductService.Pagination(int pageNumber, int pageSize)
        {
            if (pageNumber > 0 || pageSize > 0)
            {
                List<Product> ans3 = SeedData.Products.Skip((pageNumber - 1) * pageSize)
                                                        .Take(pageSize)
                                                        .ToList();
                return ans3;
            }
            else
            {
                return null;
            }
        }

        //bai 4
        public Product Search(int id)
        {
            Product? product = SeedData.Products.FirstOrDefault(p => p.Id == id);
            if (product is null)
            {
                return NotFound(new );
            }
            else
            {
                return product;
            }
        }
        //bai 5
        public double TotalPrice()
        {
            double ans5 = SeedData.Products.Sum(p => p.Price * p.Stock);
            return ans5;
        }
        //bai 6
        public Product MaxPrice()
        {
            Product? ans6 = SeedData.Products.Where(p => p.Stock > 0)
                                             .MaxBy(p => p.Price);
            return ans6;
        }
        //bai 11
        public List<CategoryWithProductsDto> CategoryStatistics()
        {
            List<CategoryWithProductsDto> ans11 = SeedData.Categories.GroupJoin(SeedData.Products,
                                                                      CategoryId => CategoryId.Id,
                                                                      ProductCt => ProductCt.CategoryId,                                                                
                                                                      (CategoryId, ProductCt) => new CategoryWithProductsDto
                                                                      {
                                                                          CategoryId = CategoryId.Id,
                                                                          CategoryName = CategoryId.Name,
                                                                          Products = ProductCt.Select(p => new Product()
                                                                          {
                                                                              Id = p.Id,
                                                                              Name = p.Name,
                                                                              Price = p.Price,
                                                                              Stock = p.Stock,
                                                                          })
                                                                          .ToList()
                                                                      })
                                                                    .ToList();
            return ans11;
        }
        //bai 12
        public List<Product> UnsoldProducts()
        {
            List<Product> ans12 = SeedData.Products.GroupJoin(SeedData.Orders.Where(p => p.Status == "Completed"),
                                               ProductId => ProductId.Id,
                                               OrderPr => OrderPr.ProductId,
                                               (Product, OrderPr) => new
                                               {
                                                   Pro = Product,
                                                   Oder = OrderPr,
                                               }) 
                                                .Where(p => !p.Oder.Any())
                                                //.Select(p => new Product()
                                                //{
                                                //    Id =p.Pro.Id,
                                                //    CategoryId = p.Pro.CategoryId,
                                                //    Name = p.Pro.Name,
                                                //    Price = p.Pro.Price,
                                                //    Stock = p.Pro.Stock
                                                //})
                                                .Select(p => p.Pro)
                                                .ToList();

            return ans12;
        }
        //bai 14
        public List<TopProductDto> TopProduct()
        {
            List<TopProductDto> ans14 = SeedData.Orders.Where(p => p.Status == "Completed")
                                                        .Join(SeedData.Products,
                                                         OrderPr => OrderPr.ProductId,
                                                         ProducId => ProducId.Id,
                                                         (OrderPr, ProducId) => new
                                                         {
                                                             OrderPr = OrderPr,
                                                             ProducId = ProducId
                                                         })
                                                        .GroupBy(p => new
                                                        {
                                                            p.ProducId.Id,
                                                            p.ProducId.Name
                                                        })
                                                        .Select(q => new TopProductDto
                                                        {
                                                            ProductId = q.Key.Id,
                                                            ProducName = q.Key.Name,
                                                            TotalQuantitySold = q.Sum(q => q.OrderPr.Quantity)
                                                        })
                                                        .OrderByDescending(q => q.TotalQuantitySold)
                                                        .Take(3)
                                                        .ToList();
            return ans14;                                           
        }
        
    
    }
}
