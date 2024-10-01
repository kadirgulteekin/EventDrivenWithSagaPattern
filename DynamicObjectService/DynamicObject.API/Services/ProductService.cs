using DynamicObject.Domain.Model;

namespace DynamicObject.API.Services
{
    public class ProductService : IProductService
    {

        private readonly IRepository<Product> _productRepository;
        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task HandleAsync(Product  product)
        {
    
            await _productRepository.AddAsync(product);
        }
    }
}
