using DynamicObject.Domain.Model;

namespace DynamicObject.API.Services
{
    public interface IProductService
    {
        Task HandleAsync(Product product);
    }
}
