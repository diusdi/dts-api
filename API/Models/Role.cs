namespace API.Models
{
    public class Role
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
