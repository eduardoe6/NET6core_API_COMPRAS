using Microsoft.EntityFrameworkCore;
using net6_api_compras.Domain.Entities;
using net6_api_compras.Domain.Repositories;
using net6_api_compras.Infra.Data.Context;

namespace net6_api_compras.Infra.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> GetIdByCodeErpAsync(string codErp)
        {
            return (await _context.Products.FirstOrDefaultAsync(x => x.CodErp == codErp))?.Id ?? 0;
        }
    }
}
