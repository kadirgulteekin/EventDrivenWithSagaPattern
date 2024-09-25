using DynamicObject.API.EventBus.Events;
using DynamicObject.API.Services;
using DynamicObject.Domain.ControllerBases;
using DynamicObject.Domain.Model;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Dynamic;
using System.Text.Json;

namespace DynamicObject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DynamicObjectController : CustomBaseController
    {
         
        private readonly IDynamicObjectService _dynamicObjectService;



        public DynamicObjectController(IDynamicObjectService dynamicObjectService, ISendEndpointProvider sendEndpointProvider)
        {
            _dynamicObjectService = dynamicObjectService;
         
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var dynamicOnject = await _dynamicObjectService.GetDynamicObjectAsync(id);
            return Ok(dynamicOnject);
        }

        
        [HttpPost()]
        public async Task<IActionResult> Create(ObjectCreatedEvent dynamicObjectModel)
        {
            try
            {

                var createdDynamicObject = await _dynamicObjectService.CreateDynamicObjectAsync(dynamicObjectModel);

                return CreateActionResultInstance(createdDynamicObject);
              
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Error occurred while creating dynamic object: {ex.Message}");
            }
           
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(Guid id,DynamicObjectModel dynamicObjectModel)
        {
           await _dynamicObjectService.UpdateDynamicObjectAsync(id, dynamicObjectModel);
           return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _dynamicObjectService.DeleteDynamicObjectAsync(id);
            return NoContent();
        }
    }
}
