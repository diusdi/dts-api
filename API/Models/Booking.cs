using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tb_tr_bookings")]
    public class Booking : BaseEntitiy
    {
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        [Column("end_date")]
        public DateTime EndDate { get; set; }
        [Column("status")]
        public int Status  { get; set; }
        [Column("remarks", TypeName = "nvarchar(MAX)")]
        public string Remarks { get; set; }
        [Column("room_guid")]
        public Guid RoodGuid { get; set; }
        [Column("employee_guid")]
        public Guid EmployeeGuid { get; set; }
    }
}
