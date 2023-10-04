using API.DTOs.Accounts;
using FluentValidation;

namespace API.Utilities.Validations.Accounts;

public class CreateAccountValidator : AbstractValidator<CreateAccountDto>
{
    public CreateAccountValidator()
    {
        RuleFor(e => e.Password)
           .NotEmpty()
           .MinimumLength(8);

        RuleFor(e => e.Otp)
           .NotEmpty();

        RuleFor(e => e.IsUsed)
           .NotEmpty()
           .IsInEnum();

        RuleFor(e => e.ExpiredTime).NotEmpty();
    }
}
