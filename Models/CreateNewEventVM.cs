using Code_Academy___Conference_Management_System.Entities;

namespace Code_Academy___Conference_Management_System.Models
{
    public class CreateNewEventVM
    {
        public EventVM EventVM { get; set; } = new();
        public List<EventVM> EventVMs { get; set; } = new();
    }
}
