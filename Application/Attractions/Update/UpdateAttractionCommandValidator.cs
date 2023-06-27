using FluentValidation;

namespace Application.Attractions.Update;

public class UpdateAttractionCommandValidator : AbstractValidator<UpdateAttractionCommand>
{
    public UpdateAttractionCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

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
