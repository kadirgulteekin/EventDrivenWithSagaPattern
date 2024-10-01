namespace DynamicObject.API.Services
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity);
    }
}
