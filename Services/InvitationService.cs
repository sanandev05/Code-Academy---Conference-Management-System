using Code_Academy___Conference_Management_System.Models;
using Code_Academy___Conference_Management_System.Repositories.Interfaces;
using Code_Academy___Conference_Management_System.Services.Interfaces;

namespace Code_Academy___Conference_Management_System.Services
{
    public class InvitationService : IInvitationService
    {
        private readonly IInvitationRepository _invitationRepository;
        public InvitationService(IInvitationRepository invitationRepository)
        {
            _invitationRepository = invitationRepository;

        }

        public Task<InvitationVM> AddAsync(InvitationVM model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InvitationVM>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<InvitationVM> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(InvitationVM model)
        {
            throw new NotImplementedException();
        }
    }
}
