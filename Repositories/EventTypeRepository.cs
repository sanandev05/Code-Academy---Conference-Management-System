using Code_Academy___Conference_Management_System.Data;
using Code_Academy___Conference_Management_System.Entities;
using Code_Academy___Conference_Management_System.Repositories.Interfaces;

namespace Code_Academy___Conference_Management_System.Repositories
{
    public class EventTypeRepository : GenericRepository<EventType>, IEventTypeRepository
    {
        private readonly ConferenceDbContext _context;
        public EventTypeRepository(ConferenceDbContext context) : base(context)
        {
            _context = context;
        }
    }

}
