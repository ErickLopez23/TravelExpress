using FluentValidation;

namespace Application.Bookings.Create;

public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
{
    public CreateBookingCommandValidator()
    {
        RuleFor(x => x.PlanId).NotEmpty();

        RuleFor(x => x.CustomerName)
            .NotEmpty();

        RuleFor(x => x.CustomerPhone)
            .NotEmpty();

        RuleFor(x => x.CustomerEmail)
            .NotEmpty();
    }
}
