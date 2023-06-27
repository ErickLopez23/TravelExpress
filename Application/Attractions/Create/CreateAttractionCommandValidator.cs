using FluentValidation;

namespace Application.Attractions.Create;

public class CreateAttractionCommandValidator : AbstractValidator<CreateAttractionCommand>
{
    public CreateAttractionCommandValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(x => x.Description)
            .MaximumLength(255)
            .NotEmpty();

        RuleFor(x => x.Country)
            .MaximumLength(50)
            .NotEmpty();
    }
}
