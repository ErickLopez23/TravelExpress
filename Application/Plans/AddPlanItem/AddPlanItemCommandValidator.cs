using FluentValidation;

namespace Application.Plans.AddPlanItem;

public class AddPlanItemCommandValidator : AbstractValidator<AddPlanItemCommand>
{
    public AddPlanItemCommandValidator()
    {
        RuleFor(x => x.PlanId)
            .NotEmpty();

        RuleFor(x => x.AttractionId)
            .NotEmpty();
    }
}
