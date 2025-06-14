using Code_Academy___Conference_Management_System.Entities;
using Code_Academy___Conference_Management_System.Models;

namespace Code_Academy___Conference_Management_System.Services.Interfaces
{
    public interface IEventTypeService
    {
        Task<EventTypeVM> AddAsync(EventTypeVM model);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<EventTypeVM>> GetAllAsync();
        Task<EventTypeVM> GetByIdAsync(int id);
        Task UpdateAsync(EventTypeVM model);
    }
}
