using Code_Academy___Conference_Management_System.Data;
using Code_Academy___Conference_Management_System.Entities;
using Code_Academy___Conference_Management_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Code_Academy___Conference_Management_System.Repositories
{
    public class InvitationRepository : GenericRepository<Invitation>, IInvitationRepository
    {
        private readonly ConferenceDbContext _conferenceDbContext;
        public InvitationRepository(ConferenceDbContext context) : base(context)
        {
            _conferenceDbContext = context;
        }
    }
}
