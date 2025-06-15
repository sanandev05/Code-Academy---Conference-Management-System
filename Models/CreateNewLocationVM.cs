namespace Code_Academy___Conference_Management_System.Models
{
    public class CreateNewLocationVM
    {
        public LocationVM LocationVM { get; set; }
        public List<LocationVM>? Locations { get; set; }
    }
}