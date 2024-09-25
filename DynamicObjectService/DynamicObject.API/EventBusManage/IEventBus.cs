using DynamicObject.API.EventBus.Event;


namespace DynamicObject.API.EventBusManage
{
    public interface IEventBus
    {
        Task Publish<T>(T @event) where T : IntegrationEvent;
    }

 
}
