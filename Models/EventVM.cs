using Code_Academy___Conference_Management_System.Entities;

namespace Code_Academy___Conference_Management_System.Models
{
    public class EventVM : BaseEntityVM
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int LocationId { get; set; }
        public LocationVM Location { get; set; }

        public int EventTypeId { get; set; }
        public EventTypeVM EventType { get; set; }

        public int OrganizerId { get; set; }
        public OrganizerVM Organizer { get; set; }
    }
}
