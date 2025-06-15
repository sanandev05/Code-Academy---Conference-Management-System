using Code_Academy___Conference_Management_System.Data;
using Code_Academy___Conference_Management_System.Entities;
using Code_Academy___Conference_Management_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Code_Academy___Conference_Management_System.Repositories
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        private readonly ConferenceDbContext _context;
        public LocationRepository(ConferenceDbContext context) : base(context)
        {
            _context = context;
        }

        
    }
}
