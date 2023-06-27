using ErrorOr;
using MediatR;

namespace Application.Attractions.Update;

public record UpdateAttractionCommand(
    Guid Id,
    string Name,
    string Description,
    string Country
) : IRequest<ErrorOr<Unit>>;
