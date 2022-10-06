using net6_api_compras.Domain.Entities;

namespace net6_api_compras.Domain.Repositories
{
    public interface IPurchaseRepository : IBaseRepository<Purchase>
    {
        Task<ICollection<Purchase>> GetByPersonId(int personId);
        Task<ICollection<Purchase>> GetByProductId(int productId);
    }
}
