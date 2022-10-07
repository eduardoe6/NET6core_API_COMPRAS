using Microsoft.EntityFrameworkCore;
using net6_api_compras.Domain.Entities;
using net6_api_compras.Domain.Repositories;
using net6_api_compras.Infra.Data.Context;

namespace net6_api_compras.Infra.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly AppDbContext _context;

        public PurchaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Purchase> CreateAsync(Purchase purchase)
        {
            _context.Add(purchase);
            await _context.SaveChangesAsync();
            return purchase;
        }

        public async Task RemoveAsync(Purchase purchase)
        {
            _context.Remove(purchase);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Purchase purchase)
        {
            _context.Update(purchase);
            await _context.SaveChangesAsync();
        }

        public async Task<Purchase> GetAsync(int id)
        {
            var purchase = await _context.Purchases
                            .Include(x => x.Product)
                            .Include(x => x.Person)
                            .FirstOrDefaultAsync(x => x.Id == id);

            return purchase;
        }
        public async Task<ICollection<Purchase>> GetAllAsync()
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
