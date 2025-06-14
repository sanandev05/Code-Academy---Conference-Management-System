namespace Code_Academy___Conference_Management_System.Models
{
    public class SignUpVM : BaseEntityVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role PersonRole { get; set; } = Role.Attendee;

        public enum Role
        {
            Speaker,
            Attendee,
            Organizer
        }
    }
}
