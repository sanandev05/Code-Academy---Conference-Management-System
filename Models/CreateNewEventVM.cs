using Code_Academy___Conference_Management_System.Entities;

namespace Code_Academy___Conference_Management_System.Models
{
    public class CreateNewEventVM
    {
        public EventVM EventVM { get; set; } = new();
        public List<EventVM>? EventVMs { get; set; } = new();

        public List<EventTypeVM>? EventTypes { get; set; }
        public List<LocationVM>? Locations { get; set; }
        public List<OrganizerVM>? Organizers { get; set; }
    }

}
