using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Code_Academy___Conference_Management_System.Entities
{
    public class Notification : BaseEntity
    {
        public int EventId { get; set; }


        public string Message { get; set; }

        public DateTime SentAt { get; set; }

        public Event Event { get; set; }
    }

}
