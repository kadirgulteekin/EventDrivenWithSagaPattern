using DynamicObject.Domain.Model;
using DynamicObject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DynamicObject.API.Services
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task AddAsync(Product entity)
        {
            try
            {
                if (entity is Product product)
                {
                    // Product alt nesnelerini kontrol et
                    if (product.Details == null || !product.Details.Any())
                    {
                        throw new InvalidOperationException("Product must have at least one detail.");
                    }

                    if (product.Images == null || !product.Images.Any())
                    {
                        throw new InvalidOperationException("Product must have at least one image.");
                    }

                    // Alt nesneleri ekle
                    foreach (var detail in product.Details)
                    {
                        detail.Product = product;
                        await _applicationDbContext.Set<ProductDetail>().AddAsync(detail);
                    }

                    foreach (var image in product.Images)
                    {
                        image.Product = product;
                        await _applicationDbContext.Set<ProductImage>().AddAsync(image);
                    }
                }

                // Dinamik nesneyi ekle
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                // Log the inner exception
                Console.WriteLine($"An error occurred while saving changes: {dbEx.InnerException?.Message}");
                throw; // Re-throw the exception after logging
            }
            catch (Exception ex)
            {
                // Log the general exception
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw; // Re-throw the exception after logging
            }
        }



    }
}
