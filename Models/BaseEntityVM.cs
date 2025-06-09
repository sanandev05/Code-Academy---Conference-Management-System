using System.ComponentModel.DataAnnotations;

namespace Code_Academy___Conference_Management_System.Models
{
    public class BaseEntityVM
    {
        [Key]
        public int ID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
