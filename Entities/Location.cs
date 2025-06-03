namespace Code_Academy___Conference_Management_System.Entities
{
    public class Location : BaseEntity
    {

        public string Name { get; set; }
        public string Address { get; set; }

        public int Capacity { get; set; }
    }

}
