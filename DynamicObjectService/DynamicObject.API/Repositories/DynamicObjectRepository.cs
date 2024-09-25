using DynamicObject.API.EventBus.Events;
using DynamicObject.API.EventBusManage;
using DynamicObject.Domain.Model;
using DynamicObject.Infrastructure.Data;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace DynamicObject.API.Services
{
    public class DynamicObjectRepository : IDynamicObjectRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IEventBus _eventBus;
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public DynamicObjectRepository(ApplicationDbContext applicationDbContext,IEventBus eventBus,ISendEndpointProvider sendEndpointProvider)
        {
            _applicationDbContext = applicationDbContext;
            _eventBus = eventBus;
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task<Domain.Helper.HelperModel.Response<DynamicObjectModel>> AddObjectAsync(ObjectCreatedEvent dynamicObject)
        {
            using var transaction = await _applicationDbContext.Database.BeginTransactionAsync();
            try
            {
                dynamicObject.Id = Guid.NewGuid();

                var objectModelItem = new ObjectCreatedEvent
                {
                    ObjectDescription = dynamicObject.ObjectDescription,
                    ObjectType = dynamicObject.ObjectType,
                    ObjectFields = new List<ObjectField>()
                };

                var objectFieldsCopy = dynamicObject.ObjectFields.ToList();
                foreach (var item in objectFieldsCopy)
                {
                    var objectItem = new ObjectField
                    {
                        DynamicObjectModelId = item.DynamicObjectModelId,
                        IsRequired = item.IsRequired,
                        ObjectdName = item.ObjectdName,
                        ObjectType = item.ObjectType,
                        Quantity = item.Quantity,
                        ObjectDatas = new List<ObjectData>()

                    };
                    if (item.ObjectDatas != null && item.ObjectDatas.Any())
                    {
                        foreach (var data in item.ObjectDatas)
                        {
                            objectItem.ObjectDatas.Add(new ObjectData
                            {
                                ObjectFieldId = data.ObjectFieldId,
                                ObjectValues = data.ObjectValues
                            });
                        }
                    }
                    objectModelItem.ObjectFields.Add(objectItem);



                }




                if (dynamicObject.ObjectFields == null ||
                     !dynamicObject.ObjectFields.Any() ||
                     dynamicObject.ObjectFields.Any(field => field.ObjectDatas == null || !field.ObjectDatas.Any()))
                {

                    throw new ArgumentException("SubObjectsNotFound");
                }

       


                var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:object-created-event"));

                
                
                await sendEndpoint.Send<ObjectCreatedEvent>(objectModelItem);


                await transaction.CommitAsync();



                return Domain.Helper.HelperModel.Response<DynamicObjectModel>.Success(StatusCodes.Status200OK );
            }
            catch (Exception)
            {

                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var dynamicObject = await _applicationDbContext.DynamicObjectModels.FindAsync(id);
            if (dynamicObject != null)
            {
                _applicationDbContext.DynamicObjectModels.Remove(dynamicObject);
                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<DynamicObjectModel> FindAsyncById(Guid id)
        {
            return await _applicationDbContext.DynamicObjectModels
            .Include(o => o.ObjectFields)
                .ThenInclude(f => f.ObjectDatas)
            .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<DynamicObjectModel> GetByIdAsync(Guid id)
        {
            var objectData = await _applicationDbContext.DynamicObjectModels.FindAsync(id);

            var objectFields = await (from objectField in _applicationDbContext.ObjectFields
                                      where objectField.DynamicObjectModelId == objectData.Id
                                      select new ObjectField
                                      {
                                          Id = objectField.Id,
                                          DynamicObjectModelId = objectData.Id,
                                          ObjectdName = objectField.ObjectdName,
                                          ObjectType = objectField.ObjectType,
                                          IsRequired = objectField.IsRequired,
                                          Quantity = objectField.Quantity,
                                          ObjectDatas = _applicationDbContext.ObjectDatas
                                                        .Where(od => od.ObjectFieldId == objectField.Id)
                                                        .ToList()
                                      }).ToListAsync();



            objectData.ObjectFields = objectFields;
            return objectData;

        }

        public async Task<List<ObjectField>> GetByDynamicObjectModelIdAsync(Guid dynamicObjectModelId)
        {
            return await _applicationDbContext.ObjectFields
                .Where(field => field.DynamicObjectModelId == dynamicObjectModelId)
                .ToListAsync();

        }

        public async Task UpdateAsync(DynamicObjectModel dynamicObject)
        {
            _applicationDbContext.DynamicObjectModels.Update(dynamicObject);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task RollbackOrderAsync(int dynamicObjectId)
        {
            var objectModel = await _applicationDbContext.DynamicObjectModels.FindAsync(dynamicObjectId);
            if (objectModel!= null)
            {
                _applicationDbContext.DynamicObjectModels.Remove(objectModel);
                await _applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
