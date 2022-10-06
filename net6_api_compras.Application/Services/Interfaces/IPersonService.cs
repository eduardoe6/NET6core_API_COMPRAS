using net6_api_compras.Application.DTOs;

namespace net6_api_compras.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
        Task<ResultService> RemoveAsync(int id);
        Task<ResultService> UpdateAsync(PersonDTO personDTO);
        Task<ResultService<ICollection<PersonDTO>>> GetAllAsync();
        Task<ResultService<PersonDTO>> GetAsync(int id);
    }
}
