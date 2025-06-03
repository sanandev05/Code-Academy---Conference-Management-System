using System.ComponentModel.DataAnnotations;

namespace Code_Academy___Conference_Management_System.Entities
{
    public class Event : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int EventTypeId { get; set; }
        public EventType EventType { get; set; }

        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; }

    }
}
