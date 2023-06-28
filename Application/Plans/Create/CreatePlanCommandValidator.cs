using FluentValidation;

namespace Application.Plans.Create;

public class CreatePlanCommandValidator : AbstractValidator<CreatePlanCommand>
{
    public CreatePlanCommandValidator()
    {
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

        RuleFor(x => x.PlanItems)
            .NotNull();
    }
}
