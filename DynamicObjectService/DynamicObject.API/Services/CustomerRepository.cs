using DynamicObject.Domain.Model;
using DynamicObject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DynamicObject.API.Services
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task AddAsync(Customer entity)
        {

            try
            {
                // Eğer gelen nesne Customer ise, alt nesneleri kontrol et
                if (entity is Customer customer)
                {
                    // Customer alt nesnelerini kontrol et (örneğin, adresler)
                    if (customer.Addresses == null || !customer.Addresses.Any())
                    {
                        throw new InvalidOperationException("Customer must have at least one address.");
                    }

                    // Alt nesneleri ekle
                    foreach (var address in customer.Addresses)
                    {
                        address.Customer = customer;
                        await _applicationDbContext.Set<CustomerAddress>().AddAsync(address);
                    }

                    if (customer.Orders != null)
                    {
                        foreach (var order in customer.Orders)
                        {
                            order.Customer = customer;
                            await _applicationDbContext.Set<CustomerOrder>().AddAsync(order);
                        }
                    }
                }

                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

            
            
            
        }
    }
}
