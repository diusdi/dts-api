namespace API.Models
{
    public class AccountRole : BaseEntitiy
    {
        public Guid AccountGuid { get; set; }
        public Guid RoleGuid { get; set; }
    }
}
