using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Code_Academy___Conference_Management_System.User;

namespace Code_Academy___Conference_Management_System.Entities
{
    public class Feedback : BaseEntity
    {
        public int EventId { get; set; }

        public string UserId { get; set; }


        public int Rating { get; set; }

        public string Comment { get; set; }

        public DateTime SubmittedAt { get; set; }

        public Event Event { get; set; }

        public UserIdentity User { get; set; }
    }

}
