namespace API.Models
{
    public class Room : BaseEntitiy
    {
        public string Name { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; set; }
    }
}
