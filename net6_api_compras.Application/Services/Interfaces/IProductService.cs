using net6_api_compras.Application.DTOs;

namespace net6_api_compras.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO);
        Task<ResultService> RemoveAsync(int id);
        Task<ResultService> UpdateAsync(ProductDTO productDTO);
        Task<ResultService<ICollection<ProductDTO>>> GetAllAsync();
        Task<ResultService<ProductDTO>> GetAsync(int id);
    }
}
