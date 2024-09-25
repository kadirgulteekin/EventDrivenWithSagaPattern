
using DynamicObject.API.EventBusManage;
using DynamicObject.API.Services;

namespace DynamicObject.API.Mapping
{
    public class ServiceConfigurator
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDynamicObjectService, DynamicObjectService>();
            serviceCollection.AddScoped<IDynamicObjectRepository, DynamicObjectRepository>();
            serviceCollection.AddScoped<IEventBus, DynamicObject.API.EventBusManage.EventBus>();

        }
    }
}
