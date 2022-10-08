namespace net6_api_compras.Domain.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> CreateAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task RemoveAsync(T obj);
        Task<T> GetAsync(int id);
        Task<ICollection<T>> GetAllAsync();
    }
}
