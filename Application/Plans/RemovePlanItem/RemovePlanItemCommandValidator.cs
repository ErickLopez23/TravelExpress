using FluentValidation;

namespace Application.Plans.RemovePlanItem;

public class RemovePlanItemCommandValidator : AbstractValidator<RemovePlanItemCommand>
{
    public RemovePlanItemCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
