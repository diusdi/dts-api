namespace API.Models
{
    public abstract class BaseEntitiy
    {
        public Guid Guid { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
