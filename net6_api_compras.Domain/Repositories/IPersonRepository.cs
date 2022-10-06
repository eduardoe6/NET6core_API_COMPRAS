using net6_api_compras.Domain.Entities;

namespace net6_api_compras.Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> CreateAsync(Person person);
        Task<Person> UpdateAsync(Person person);
        Task RemoveAsync(Person person);
        Task<Person> GetAsync(int id);
        Task<ICollection<Person>> GetAllAsync();
    }
}
