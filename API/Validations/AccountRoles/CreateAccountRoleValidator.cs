using API.DTOs.AccountRoles;
using FluentValidation;

namespace API.Utilities.Validations.AccountRoles;

public class CreateAccountRoleValidator : AbstractValidator<CreateAccountRoleDto>
{
    public CreateAccountRoleValidator()
    {
        RuleFor(e => e.AccountGuid)
           .NotEmpty().WithMessage("Tidak Boleh Kosong");

        RuleFor(e => e.RoleGuid)
           .NotEmpty().WithMessage("Tidak Boleh Kosong");
    }
}
