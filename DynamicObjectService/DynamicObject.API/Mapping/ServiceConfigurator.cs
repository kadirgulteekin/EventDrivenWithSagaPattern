
using DynamicObject.API.Services;
using DynamicObject.Domain.Model;
using DynamicObject.Infrastructure.Data;
using Microsoft.OpenApi.Models;

namespace DynamicObject.API.Mapping
{
    public class ServiceConfigurator
    {
        public static void Configure(IServiceCollection serviceCollection)
        {


            // Repository'leri kaydedin
            serviceCollection.AddScoped<IRepository<Product>, ProductRepository>();
            serviceCollection.AddScoped<IRepository<Customer>, CustomerRepository>();

            serviceCollection.AddScoped<ICustomerService, CustomerService>();
            serviceCollection.AddScoped<IProductService, ProductService>();


            // Servislerinizi kaydedin
            serviceCollection.AddScoped<IBaseService<Product>>(provider => new BaseService<Product>(provider.GetRequiredService<IRepository<Product>>()));
            serviceCollection.AddScoped<IBaseService<Customer>>(provider => new BaseService<Customer>(provider.GetRequiredService<IRepository<Customer>>()));

            // DynamicObjectService'i kaydedin
            serviceCollection.AddScoped<IDynamicObjectService, DynamicObjectService>();



        }
    }
}
