using Microsoft.AspNetCore.Identity;

namespace Code_Academy___Conference_Management_System.User
{
    public class UserIdentity : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }


        public Role PersonRole { get; set; }

        public enum Role
        {
            Speaker,
            Attendee,
            Organizer
        }

    }
}
