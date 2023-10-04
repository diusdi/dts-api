using API.DTOs.Accounts;
using FluentValidation;

namespace API.Utilities.Validations.Accounts;

public class CreateAccountValidator : AbstractValidator<CreateAccountDto>
{
    public CreateAccountValidator()
    {
        RuleFor(e => e.Password)
           .NotEmpty().WithMessage("Tidak Boleh Kosong")
           .MinimumLength(8);

        RuleFor(e => e.Otp)
           .NotEmpty().WithMessage("Tidak Boleh Kosong");

        RuleFor(e => e.IsUsed)
           .NotEmpty().WithMessage("Tidak Boleh Kosong")
           .IsInEnum();

        RuleFor(e => e.ExpiredTime)
            .NotEmpty().WithMessage("Tidak Boleh Kosong");
    }
}
