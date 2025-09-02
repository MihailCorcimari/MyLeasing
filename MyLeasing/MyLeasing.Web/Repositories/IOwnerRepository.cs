using global::MyLeasing.Common.Entities;

namespace MyLeasing.Web.Repositories
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetAllAsync();
        Task<Owner?> GetByIdAsync(int id);
        Task AddAsync(Owner owner);
        Task UpdateAsync(Owner owner);
        Task DeleteAsync(Owner owner);
        Task<bool> ExistsAsync(int id);
        Task<int> SaveChangesAsync();
    }
}
