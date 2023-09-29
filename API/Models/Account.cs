using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tb_m_accounts")]
    public class Account : BaseEntitiy
    {
        [Column("password", TypeName ="nvarchar(MAX)")]
        public string Password { get; set; }
        [Column("otp")]
        public int Otp { get; set; }
        [Column("is_used")]
        public bool IsUsed { get; set; }
        [Column("expired_time")]
        public DateTime ExpiredTime  { get; set; }

        public Employee? Employee { get; set; }
        public ICollection<AccountRole>? AccountRoles { get; set; }
    }
}
