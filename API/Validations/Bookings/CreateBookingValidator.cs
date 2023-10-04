using API.DTOs.Bookings;
using FluentValidation;

namespace API.Utilities.Validations.Bookings;

public class CreateBookingValidator : AbstractValidator<CreateBookingDto>
{
    public CreateBookingValidator()
    {
        RuleFor(e => e.StartDate)
           .NotEmpty().WithMessage("Tidak Boleh Kosong");

        RuleFor(e => e.EndDate)
           .NotEmpty().WithMessage("Tidak Boleh Kosong");

        RuleFor(e => e.Status)
           .NotEmpty().WithMessage("Tidak Boleh Kosong");

        RuleFor(e => e.Remarks)
            .NotEmpty().WithMessage("Tidak Boleh Kosong");

        RuleFor(e => e.RoomGuid)
           .NotEmpty().WithMessage("Tidak Boleh Kosong");

        RuleFor(e => e.EmployeeGuid)
           .NotEmpty().WithMessage("Tidak Boleh Kosong");
    }
}
