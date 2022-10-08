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

        public override async Task<Purchase> GetAsync(int id)
        {
            var purchase = await _context.Purchases
                            .Include(x => x.Product)
                            .Include(x => x.Person)
                            .FirstOrDefaultAsync(x => x.Id == id);

            return purchase;
        }

        public override async Task<ICollection<Purchase>> GetAllAsync()
        {
            return await _context.Purchases
                            .Include(x => x.Product)
                            .Include(x => x.Person)
                            .ToListAsync();
        }

        public async Task<ICollection<Purchase>> GetByPersonIdAsync(int personId)
        {
            return await _context.Purchases
                            .Include(x => x.Product)
                            .Include(x => x.Person)
                            .Where(x => x.PersonId == personId).ToListAsync();

        }

        public async Task<ICollection<Purchase>> GetByProductIdAsync(int productId)
        {
            return await _context.Purchases
                            .Include(x => x.Product)
                            .Include(x => x.Person)
                            .Where(x => x.ProductId == productId).ToListAsync();
        }
    }
}
