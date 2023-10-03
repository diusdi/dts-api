using API.Models;

namespace API.DTOs.AccountRoles
{
    public class CreateAccountRoleDto
    {
        public Guid Guid { get; set; }
        public Guid AccountGuid { get; set; }
        public Guid RoleGuid { get; set; }

        public static implicit operator AccountRole(CreateAccountRoleDto createAccountRoleDto)
        {
            return new AccountRole
            {
                Guid = createAccountRoleDto.Guid,
                AccountGuid = createAccountRoleDto.AccountGuid,
                RoleGuid = createAccountRoleDto.RoleGuid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
