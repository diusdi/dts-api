namespace API.Models
{
    public class Education : BaseEntitiy
    {
        public string Major { get; set; }
        public string Degree { get; set; }
        public float Gpa { get; set; }
        public Guid UniversityGuid { get; set; }
    }
}
