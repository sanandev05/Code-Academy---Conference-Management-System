using System.ComponentModel.DataAnnotations;

namespace Code_Academy___Conference_Management_System.Entities
{
    public class Person : BaseEntity
    {
        public string Name{ get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Role PersonRole { get; set; }
        
        public enum Role
        {
            Speaker,
            Attendee,
            Organizer
        }

    }
}
