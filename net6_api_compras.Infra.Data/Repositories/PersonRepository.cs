using Microsoft.EntityFrameworkCore;
using net6_api_compras.Domain.Entities;
using net6_api_compras.Domain.Repositories;
using net6_api_compras.Infra.Data.Context;

namespace net6_api_compras.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<Person> CreateAsync(Person person)
        {
            _context.Add(person);
            await _context.SaveChangesAsync();

            return person;
        }

        public virtual async Task<Person> UpdateAsync(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return person;
        }

        public virtual async Task RemoveAsync(Person person)
        {
            _context.Remove(person);

            await _context.SaveChangesAsync();
        }

        public virtual async Task<Person> GetAsync(int id)
        {
            var person = await _context.Set<Person>()
                                    .AsNoTracking()
                                    .Where(x => x.Id == id)
                                    .ToListAsync();

            return person.FirstOrDefault();
        }

        public virtual async Task<ICollection<Person>> GetAllAsync()
        {
            return await _context.Set<Person>()
                                    .AsNoTracking()
                                    .ToListAsync();
        }
    }
}
