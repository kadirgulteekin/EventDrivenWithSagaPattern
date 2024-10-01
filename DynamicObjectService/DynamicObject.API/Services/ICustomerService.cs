using DynamicObject.Domain.Model;

namespace DynamicObject.API.Services
{
    public interface ICustomerService
    {
        Task HandleAsync(Customer customer);
    }
}
