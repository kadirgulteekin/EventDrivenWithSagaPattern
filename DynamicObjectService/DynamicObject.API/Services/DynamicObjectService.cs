﻿using DynamicObject.API.EventBus.Events;
using DynamicObject.Domain.Helper.HelperModel;
using DynamicObject.Domain.Model;
using DynamicObject.Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace DynamicObject.API.Services
{
    public class DynamicObjectService : IDynamicObjectService
    {
        private readonly IDynamicObjectRepository _dynamicObjectRepository;

        public DynamicObjectService(IDynamicObjectRepository dynamicObjectRepository)
        {
            _dynamicObjectRepository = dynamicObjectRepository;
        }

        public async Task<Response<DynamicObjectModel>> CreateDynamicObjectAsync(ObjectCreatedEvent dynamicObjectModel)
        {
           

            await _dynamicObjectRepository.AddObjectAsync(dynamicObjectModel);

            return Response<DynamicObjectModel>.Success(StatusCodes.Status200OK);


        }

        public async Task DeleteDynamicObjectAsync(Guid id)
        {
            var dynamicObject = await _dynamicObjectRepository.GetByIdAsync(id);

            if (dynamicObject != null)
            {

                var objectFields = await _dynamicObjectRepository.GetByDynamicObjectModelIdAsync(id);
                foreach (var field in objectFields)
                {
                    await _dynamicObjectRepository.DeleteAsync(field.DynamicObjectModelId);
                }


                await _dynamicObjectRepository.DeleteAsync(id);
            }
        }


        public async Task<DynamicObjectModel> GetDynamicObjectAsync(Guid id)
        {
            var objectData = await _dynamicObjectRepository.GetByIdAsync(id);
            return objectData;
        }

        public async Task<NoContentResult> UpdateDynamicObjectAsync(Guid id, DynamicObjectModel dynamicObjectModel)
        {
            var dynamicObject = await _dynamicObjectRepository.FindAsyncById(id);

            if (dynamicObject == null) return new NoContentResult();

            dynamicObject.IsActive = dynamicObjectModel.IsActive;
            dynamicObject.ObjectDescription = dynamicObjectModel.ObjectDescription;
            dynamicObject.ObjectType = dynamicObjectModel.ObjectType;
            foreach (var updatedField in dynamicObjectModel.ObjectFields)
            {
                dynamicObject.ObjectFields[0].ObjectdName= updatedField.ObjectdName;
                dynamicObject.ObjectFields[0].ObjectType = updatedField.ObjectType;
                dynamicObject.ObjectFields[0].IsRequired = updatedField.IsRequired;
                dynamicObject.ObjectFields[0].Quantity = updatedField.Quantity;

                    foreach (var incomingData in updatedField.ObjectDatas)
                    {
                        dynamicObject.ObjectFields[0].ObjectDatas[0].ObjectValues = incomingData.ObjectValues;
                    }

            }
            await _dynamicObjectRepository.UpdateAsync(dynamicObject);

            return new NoContentResult();

        }
    }
}
