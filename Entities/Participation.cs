namespace Code_Academy___Conference_Management_System.Entities
{
    public class Participation : BaseEntity
    {
        public int InvitationId { get; set; }
        public DateTime? CheckInTime { get; set; }
        public string SeatNumber { get; set; }

        public Invitation Invitation { get; set; }
    }
}
