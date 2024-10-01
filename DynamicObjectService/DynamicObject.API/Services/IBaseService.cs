using DynamicObject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DynamicObject.API.Services
{
    public interface IBaseService<TEntity>
    {
     
        Task HandleAsync(TEntity entity);
    }


}
