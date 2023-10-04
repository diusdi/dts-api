using API.DTOs.Universities;
using FluentValidation;

namespace API.Utilities.Validations.Universitys;

public class CreateUniversityValidator : AbstractValidator<CreateUniversityDto>
{
    public CreateUniversityValidator()
    {
        RuleFor(e => e.Name)
           .NotEmpty().WithMessage("Tidak Boleh Kosong");

        RuleFor(e => e.Code)
           .NotEmpty().WithMessage("Tidak Boleh Kosong")
           .MaximumLength(5).WithMessage("Tidak Boleh Melebihi 5 Karakter");

    }
}
