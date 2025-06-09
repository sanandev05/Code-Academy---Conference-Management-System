using Code_Academy___Conference_Management_System.Models;

namespace Code_Academy___Conference_Management_System.Services.Interfaces
{
    public interface IInvitationService
    {
        Task<InvitationVM> GetByIdAsync(int id);
        Task<IEnumerable<InvitationVM>> GetAllAsync();
        Task<InvitationVM> AddAsync(InvitationVM model);
        Task UpdateAsync(InvitationVM model);
        Task<bool> DeleteAsync(int id);
    }
}
