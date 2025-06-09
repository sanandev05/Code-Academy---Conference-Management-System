using Code_Academy___Conference_Management_System.Entities;
using Code_Academy___Conference_Management_System.User;

namespace Code_Academy___Conference_Management_System.Models
{
    public class InvitationVM : BaseEntityVM
    {
        public enum Status
        {
            Pending,
            Accepted,
            Declined
        }
        public int EventId { get; set; }
        public string PersonId { get; set; }

        public Event Event { get; set; }
        public UserIdentity Person { get; set; }

        public Status InvitationStatus { get; set; } = Status.Pending;

        public DateTime SentAt { get; set; } = DateTime.Now;
    }
}
