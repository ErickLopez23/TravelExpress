using FluentValidation;

namespace Application.Attractions.Delete;

public class DeleteAttractionCommandValidator : AbstractValidator<DeleteAttractionCommand>
{
    public DeleteAttractionCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
