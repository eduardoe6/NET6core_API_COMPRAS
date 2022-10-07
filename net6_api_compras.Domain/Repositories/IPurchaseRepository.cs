using net6_api_compras.Domain.Entities;

namespace net6_api_compras.Domain.Repositories
{
    public interface IPurchaseRepository
    {
		Task<Purchase> CreateAsync(Purchase purchase);
		Task UpdateAsync(Purchase purchase);
		Task RemoveAsync(Purchase purchase);
		Task<Purchase> GetAsync(int id);
		Task<ICollection<Purchase>> GetAllAsync();
		Task<ICollection<Purchase>> GetByPersonIdAsync(int personId);
		Task<ICollection<Purchase>> GetByProductIdAsync(int productId);
	}
}
