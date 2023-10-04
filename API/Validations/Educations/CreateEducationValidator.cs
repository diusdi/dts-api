using API.DTOs.Educations;
using FluentValidation;

namespace API.Utilities.Validations.Educations;

public class CreateEducationValidator : AbstractValidator<CreateEducationDto>
{
    public CreateEducationValidator()
    {
        RuleFor(e => e.Major)
           .NotEmpty().WithMessage("Tidak Boleh Kosong");

        RuleFor(e => e.Degree)
           .NotEmpty().WithMessage("Tidak Boleh Kosong");

        RuleFor(e => e.Gpa)
           .NotEmpty().WithMessage("Tidak Boleh Kosong")
           .LessThanOrEqualTo(4).WithMessage("Tidak Boleh Melebihi 4.0");

        RuleFor(e => e.UniversityGuid)
            .NotEmpty().WithMessage("Tidak Boleh Kosong");

    }
}
