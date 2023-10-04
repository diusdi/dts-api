using API.DTOs.Rooms;
using FluentValidation;

namespace API.Utilities.Validations.Rooms;

public class CreateRoomValidator : AbstractValidator<CreateRoomDto>
{
    public CreateRoomValidator()
    {
        RuleFor(e => e.Name)
           .NotEmpty().WithMessage("Tidak Boleh Kosong");

        RuleFor(e => e.Floor)
           .NotEmpty().WithMessage("Tidak Boleh Kosong");

        RuleFor(e => e.Capacity)
           .NotEmpty().WithMessage("Tidak Boleh Kosong");
    }
}
