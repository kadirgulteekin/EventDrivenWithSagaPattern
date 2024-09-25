using DynamicObject.Domain.Helper.HelperModel;
using Microsoft.AspNetCore.Mvc;

namespace DynamicObject.Domain.ControllerBases
{
        public class CustomBaseController : ControllerBase
        {
            public IActionResult CreateActionResultInstance<T>(Response<T> response)
            {
                return new ObjectResult(response)
                {
                    StatusCode = response.StatusCode,
                    Value = response.Data
                };
            }
        }   
}
