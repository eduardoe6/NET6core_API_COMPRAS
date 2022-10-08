using Microsoft.EntityFrameworkCore;
using net6_api_compras.Domain.Entities;
using net6_api_compras.Domain.Repositories;
using net6_api_compras.Infra.Data.Context;

namespace net6_api_compras.Infra.Data.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> GetIdByDocumentAsync(string document)
        {
            return (await _context.People.FirstOrDefaultAsync(x => x.Document == document))?.Id ?? 0;
        }
    }
}
