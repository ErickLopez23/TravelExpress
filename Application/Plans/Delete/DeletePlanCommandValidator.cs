using FluentValidation;

namespace Application.Plans.Delete;

public class DeletePlanCommandValidator : AbstractValidator<DeletePlanCommand>
{
    public DeletePlanCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
