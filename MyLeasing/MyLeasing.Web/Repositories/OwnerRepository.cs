using Microsoft.EntityFrameworkCore;
using MyLeasing.Common.Entities;
using MyLeasing.Web.Data;

namespace MyLeasing.Web.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;
        public OwnerRepository(DataContext context) => _context = context;

        public async Task<IEnumerable<Owner>> GetAllAsync() =>
            await _context.Owners.OrderBy(o => o.LastName).ThenBy(o => o.FirstName).ToListAsync();

        public async Task<Owner?> GetByIdAsync(int id) =>
            await _context.Owners.FirstOrDefaultAsync(o => o.Id == id);

        public async Task AddAsync(Owner owner) => await _context.Owners.AddAsync(owner);

        public Task UpdateAsync(Owner owner)
        {
            _context.Owners.Update(owner);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Owner owner)
        {
            _context.Owners.Remove(owner);
            return Task.CompletedTask;
        }

        public Task<bool> ExistsAsync(int id) =>
            _context.Owners.AnyAsync(o => o.Id == id);

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}

