
using DynamicObject.API.EventBus.Event;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using MassTransit;

namespace DynamicObject.API.EventBusManage
{
    public class EventBus : IEventBus
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public EventBus(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Publish<T>(T @event) where T : IntegrationEvent
        {
            await _publishEndpoint.Publish(@event);
        }
    }
}
