using net6_api_compras.Domain.Entities;

namespace net6_api_compras.Domain.Repositories
{
    public interface IPurchaseRepository : IBaseRepository<Purchase>
    {
		Task<ICollection<Purchase>> GetByPersonIdAsync(int personId);
		Task<ICollection<Purchase>> GetByProductIdAsync(int productId);
	}
}
