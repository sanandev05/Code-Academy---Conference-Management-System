using Code_Academy___Conference_Management_System.Models;

namespace Code_Academy___Conference_Management_System.Services.Interfaces
{
    public interface IEventService
    {
        Task<EventVM> AddAsync(EventVM model);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<EventVM>> GetAllAsync();
        Task<EventVM> GetByIdAsync(int id);
        Task UpdateAsync(EventVM model);
    }
}
