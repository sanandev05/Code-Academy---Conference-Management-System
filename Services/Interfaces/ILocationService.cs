using Code_Academy___Conference_Management_System.Models;

namespace Code_Academy___Conference_Management_System.Services.Interfaces
{
    public interface ILocationService
    {
        Task<LocationVM> AddAsync(LocationVM model);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<LocationVM>> GetAllAsync();
        Task<LocationVM> GetByIdAsync(int id);
        Task UpdateAsync(LocationVM model);
    }

}
