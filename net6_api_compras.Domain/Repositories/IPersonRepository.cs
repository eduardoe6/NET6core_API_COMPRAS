using net6_api_compras.Domain.Entities;

namespace net6_api_compras.Domain.Repositories
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<ICollection<Person>> GetAllAsync();
        Task<int> GetIdByDocumentAsync(string document);
    }
}
