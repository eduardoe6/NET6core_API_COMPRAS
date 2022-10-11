using net6_api_compras.Application.DTOs;

namespace net6_api_compras.Application.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO);
        Task<ResultService<PurchaseDetailDTO>> GetAsync(int id);
        Task<ResultService<ICollection<PurchaseDetailDTO>>> GetAllAsync();
    }
}
