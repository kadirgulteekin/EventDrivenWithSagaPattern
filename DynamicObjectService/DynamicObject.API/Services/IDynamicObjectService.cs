﻿using DynamicObject.API.EventBus.Events;
using DynamicObject.Domain.Helper.HelperModel;
using DynamicObject.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DynamicObject.API.Services
{
    public interface IDynamicObjectService
    {
        //Task<Response<DynamicObjectModel>> CreateDynamicObjectAsync(ObjectCreatedEvent dynamicObjectModel);
        //Task<DynamicObjectModel> GetDynamicObjectAsync(Guid id);
        //Task<NoContentResult> UpdateDynamicObjectAsync(Guid id, DynamicObjectModel dynamicObjectModel);
        //Task DeleteDynamicObjectAsync(Guid id);

        Task ProductHandleAsync(JsonElement entity);
        Task CustomerHandleAsync(JsonElement entity);


    }
}
