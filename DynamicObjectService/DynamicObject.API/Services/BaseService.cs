using DynamicObject.Domain.Model;
using DynamicObject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DynamicObject.API.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity>
    {

        private readonly IRepository<TEntity> _repository;

        public BaseService(IRepository<TEntity> repository)
        {
           
            _repository = repository;
        }



        public async Task HandleAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
        }
    }
}
