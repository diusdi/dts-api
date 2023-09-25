namespace API.Models
{
    public class Booking : BaseEntitiy
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status  { get; set; }
        public string Remarks { get; set; }
        public Guid RoodGuid { get; set; }
        public Guid EmployeeGuid { get; set; }
    }
}
