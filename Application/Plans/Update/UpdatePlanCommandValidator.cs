using FluentValidation;

namespace Application.Plans.Update;

public class UpdatePlanCommandValidator : AbstractValidator<UpdatePlanCommand>
{
    public UpdatePlanCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Name)
           .MaximumLength(50)
           .NotEmpty();

        RuleFor(x => x.Description)
            .MaximumLength(255)
            .NotEmpty();

        RuleFor(x => x.Departure)
            .NotEmpty();

        RuleFor(x => x.Return)
            .NotEmpty();

        RuleFor(x => x.Price)
            .NotEmpty();
    }
}
