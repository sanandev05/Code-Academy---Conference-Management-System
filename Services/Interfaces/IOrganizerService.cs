using Code_Academy___Conference_Management_System.Entities;
using Code_Academy___Conference_Management_System.Models;

namespace Code_Academy___Conference_Management_System.Services.Interfaces
{
    public interface IOrganizerService
    {
        Task<OrganizerVM> GetByIdAsync(int id);
        Task<IEnumerable<OrganizerVM>> GetAllAsync();
        Task<OrganizerVM> AddAsync(OrganizerVM model);
        Task UpdateAsync(OrganizerVM model);
        Task<bool> DeleteAsync(int id);
    }
}
