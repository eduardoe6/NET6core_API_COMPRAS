using net6_api_compras.Domain.Entities;

namespace net6_api_compras.Domain.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<int> GetIdByCodeErpAsync(string codErp);
    }
}
