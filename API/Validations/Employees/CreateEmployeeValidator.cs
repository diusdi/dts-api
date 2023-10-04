using API.DTOs.Employees;
using FluentValidation;

namespace API.Utilities.Validations.Employees;

public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeDto>
{
    public CreateEmployeeValidator()
    {
        RuleFor(e => e.FirstName)
           .NotEmpty().WithMessage("Tidak Boleh Kosong");

        RuleFor(e => e.BirthDate)
           .NotEmpty().WithMessage("Tidak Boleh Kosong");

        RuleFor(e => e.Gender)
           .NotEmpty().WithMessage("Tidak Boleh Kosong")
           .IsInEnum();

        RuleFor(e => e.HiringDate)
            .NotEmpty().WithMessage("Tidak Boleh Kosong"); 

        RuleFor(e => e.Email)
           .NotEmpty().WithMessage("Tidak Boleh Kosong")
           .EmailAddress().WithMessage("Format Email Salah");

        RuleFor(e => e.PhoneNumber)
           .NotEmpty().WithMessage("Tidak Boleh Kosong")
           .MinimumLength(10).WithMessage("Tidak Boleh Kurang Dari 10 Digit")
           .MaximumLength(20).WithMessage("Tidak Boleh Melebihi 20 Digit");
    }
}
