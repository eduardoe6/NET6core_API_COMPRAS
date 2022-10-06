using Microsoft.EntityFrameworkCore;
using net6_api_compras.Domain.Entities;
using net6_api_compras.Domain.Repositories;
using net6_api_compras.Infra.Data.Context;

namespace net6_api_compras.Infra.Data.Repositories
{
    public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository
    {
        private readonly AppDbContext _context;

        public PurchaseRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Purchase>> GetByPersonId(int personId)
        {
            return await _context.Purchases
                                 .Include(p => p.Person)
                                 .Include(p => p.Product)
                                 .Where(p => p.PersonId == personId).ToListAsync();
        }

        public async Task<ICollection<Purchase>> GetByProductId(int productId)
        {
            return await _context.Purchases
                                 .Include(p => p.Person)
                                 .Include(p => p.Product)
                                 .Where(p => p.ProductId == productId).ToListAsync();
        }
    }
}
