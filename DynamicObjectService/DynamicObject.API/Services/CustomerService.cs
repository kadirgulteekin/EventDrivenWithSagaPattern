using DynamicObject.Domain.Model;

namespace DynamicObject.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task HandleAsync(Customer customer)
        {
            // Burada müşteri ile ilgili işlemleri gerçekleştirin
            await _customerRepository.AddAsync(customer);
        }

    }
}
