using DynamicObject.API.EventBus.Events;
using DynamicObject.Domain.Helper.HelperModel;
using DynamicObject.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace DynamicObject.API.Services
{
    public interface IDynamicObjectRepository
    {
        Task<DynamicObjectModel> GetByIdAsync(Guid id);
        Task<DynamicObjectModel> FindAsyncById(Guid id);
        Task<List<ObjectField>> GetByDynamicObjectModelIdAsync(Guid dynamicObjectModelId);
        Task<Response<DynamicObjectModel>> AddObjectAsync(ObjectCreatedEvent dynamicObject);
        Task UpdateAsync(DynamicObjectModel dynamicObject);
        Task DeleteAsync(Guid id);

        Task RollbackOrderAsync(int dynamicObjectId);
    }
}
