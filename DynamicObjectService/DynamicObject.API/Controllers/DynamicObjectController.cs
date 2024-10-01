using DynamicObject.API.Services;
using DynamicObject.Domain.ControllerBases;
using DynamicObject.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DynamicObject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DynamicObjectController : ControllerBase
    {


        private readonly IDynamicObjectService _dynamicObjectService;

        public DynamicObjectController(IDynamicObjectService dynamicObjectService)
        {
            _dynamicObjectService = dynamicObjectService;
        }


        [HttpPost]
        public async Task<IActionResult> Create(JsonElement entity)
        {
            try
            {
               
                if (entity.ValueKind == JsonValueKind.Undefined || entity.ValueKind != JsonValueKind.Object)
                {
                    return BadRequest("Entity cannot be null or undefined.");
                }


                if (entity.TryGetProperty("entityType", out var entityTypeProperty))
                {
                    string entityType = entityTypeProperty.GetString();


                    // Entity'nin türünü kontrol et
                    if (entityType == "Product")
                    {
                        var product = JsonSerializer.Deserialize<Product>(entity.GetRawText(), new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true 
                        });
                        if (product != null)
                        {
                        
                            var productJson = JsonSerializer.Serialize(product);
                            using (var document = JsonDocument.Parse(productJson))
                            {
                                JsonElement productElement = document.RootElement;
                                await _dynamicObjectService.ProductHandleAsync(productElement);
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Invalid Product data");
                        }
                    }
                    else if (entityType == "Customer")
                    {
                        var customer = JsonSerializer.Deserialize<Customer>(entity.GetRawText(), new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                        if (customer != null)
                        {
                            var customerJson = JsonSerializer.Serialize(customer);
                            using (var document = JsonDocument.Parse(customerJson))
                            {
                                JsonElement customerElement = document.RootElement;
                                await _dynamicObjectService.CustomerHandleAsync(customerElement);
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Invalid Product data");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Invalid entity type");
                    }
                }
                else
                {
                    throw new ArgumentException("Entity type not specified");
                }

                return Ok("Entity created successfully");
            }
            catch (ArgumentException argEx)
            {
                return BadRequest(argEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while creating entity: {ex.Message}");
            }
        }




    }
}
