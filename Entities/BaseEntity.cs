using System.ComponentModel.DataAnnotations;

namespace Code_Academy___Conference_Management_System.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
