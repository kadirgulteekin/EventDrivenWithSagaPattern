using DynamicObject.API.EventBus.Events;
using DynamicObject.API.EventBus.TransactionEventService;
using DynamicObject.Domain.Model;
using DynamicObject.Infrastructure.Data;
using MassTransit;

namespace DynamicObject.API.EventBus.Handler
{
    //public class ObjectCreatedEventHandler : IConsumer<ObjectCreatedEvent>
    //{
    //    private readonly ApplicationDbContext _applicationDbContext;

    //    public ObjectCreatedEventHandler(ApplicationDbContext applicationDbContext)
    //    {
    //        _applicationDbContext = applicationDbContext;
    //    }

        //public async Task Consume(ConsumeContext<ObjectCreatedEvent> context)
        //{
         

        //    var dynamicObject = new DynamicObjectModel
        //    {
        //        Id = Guid.NewGuid(),
        //        ObjectDescription = context.Message.ObjectDescription,
        //        ObjectType = context.Message.ObjectType, 
        //        IsActive = context.Message.IsActive 

        //    };


        //    if (context.Message.ObjectFields != null && context.Message.ObjectFields.Any())
        //    {
        //        foreach (var item in context.Message.ObjectFields)
        //        {
        //            var objectItem = new ObjectField
        //            {
                        
        //                DynamicObjectModelId = dynamicObject.Id,
        //                IsRequired = item.IsRequired,
        //                ObjectdName = item.ObjectdName,
        //                ObjectType = item.ObjectType,
        //                Quantity = item.Quantity,
        //                ObjectDatas = new List<ObjectData>()
        //            };

        //            if (item.ObjectDatas != null && item.ObjectDatas.Any())
        //            {
        //                foreach (var data in item.ObjectDatas)
        //                {
        //                    objectItem.ObjectDatas.Add(new ObjectData
        //                    {
        //                        ObjectFieldId = data.ObjectFieldId,
        //                        ObjectValues = data.ObjectValues
        //                    });
        //                }
        //            }
        //            dynamicObject.ObjectFields.Add(objectItem);
        //        }
        //    }

        //    await _applicationDbContext.DynamicObjectModels.AddAsync(dynamicObject);
        //    await _applicationDbContext.SaveChangesAsync();
        //}
//    }
}
