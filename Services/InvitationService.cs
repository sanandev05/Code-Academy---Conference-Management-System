using Code_Academy___Conference_Management_System.Models;
using Code_Academy___Conference_Management_System.Services.Interfaces;

namespace Code_Academy___Conference_Management_System.Services
{
    public class InvitationService : IInvitationService
    {
        private readonly IInvitationService _invitationService;
        public InvitationService(IInvitationService invitationService)
        {
            _invitationService = invitationService;
            
        }
        public Task<InvitationVM> AddAsync(InvitationVM model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<InvitationVM>> GetAllAsync()
        {
           var datas = await _invitationService.GetAllAsync();

            return datas;
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
