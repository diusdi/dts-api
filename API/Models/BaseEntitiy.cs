using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public abstract class BaseEntitiy
    {
        [Key, Column("guid")]
        public Guid Guid { get; set; }
        [Column("date_time")]
        public DateTime CreatedDate { get; set; }
        [Column("modified_date")]
        public DateTime ModifiedDate { get; set; }
    }
}
