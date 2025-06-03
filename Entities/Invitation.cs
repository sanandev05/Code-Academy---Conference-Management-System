namespace Code_Academy___Conference_Management_System.Entities
{
    public class Invitation : BaseEntity
    {
        public enum Status
        {
            Pending,
            Accepted,
            Declined
        }
        public int EventId { get; set; }
        public int PersonId { get; set; }

        public Event Event { get; set; }
        public Person Person { get; set; }

        public Status InvitationStatus { get; set; } = Status.Pending;

        public DateTime SentAt { get; set; } = DateTime.Now;
    }
}
