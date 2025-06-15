using Code_Academy___Conference_Management_System.Data;
using Code_Academy___Conference_Management_System.Entities;
using Code_Academy___Conference_Management_System.Repositories.Interfaces;

namespace Code_Academy___Conference_Management_System.Repositories
{
    public class OrganizerRepository : GenericRepository<Organizer>,IOrganizerRepository
    {
        private readonly ConferenceDbContext _conferenceDbContext;
        public OrganizerRepository(ConferenceDbContext context) : base(context)
        {
            _conferenceDbContext = context;
        }
    }
}
