namespace Code_Academy___Conference_Management_System.Models
{
    public class LocationVM : BaseEntityVM
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public int Capacity { get; set; }
    }
}
