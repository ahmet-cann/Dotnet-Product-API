using System.Diagnostics;
using FIRSTAPI.Data;
using FIRSTAPI.DTOs;
using FIRSTAPI.Models; 
using Microsoft.EntityFrameworkCore;
 
namespace FIRSTAPI.Services 
{
    public class ProductServices : IProductServices
    {
        private readonly AppDbContext _context;
        
        public ProductServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductResponse>> GetAllAsync()
        {
            return await _context.Products.Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            }).ToListAsync();
        }

        public async Task<ProductResponse> GetByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
        }

        public async Task<ProductResponse> CreateAsync(CreateProductRequest productRequest)
        {
            var product = new Product
            {
                Name = productRequest.Name,
                Description = productRequest.Description,
                Price = productRequest.Price
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
        }

        public async Task<ProductResponse> UpdateAsync(int id, UpdateProductRequest productRequest)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            product.Name = productRequest.Name;
            product.Description = productRequest.Description;
            product.Price = productRequest.Price;

            await _context.SaveChangesAsync();

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }

    public interface IProductServices
    {
    }
}