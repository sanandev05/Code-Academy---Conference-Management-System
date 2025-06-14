using Code_Academy___Conference_Management_System.Entities;

namespace Code_Academy___Conference_Management_System.Models
{
	public class CreateNewEventTypeVM
	{
		public EventTypeVM EventType { get; set; } = new();
		public List<EventTypeVM> EventTypeList { get; set; } = new();
	}
}
