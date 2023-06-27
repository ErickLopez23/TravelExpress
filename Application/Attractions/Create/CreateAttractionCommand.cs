using ErrorOr;
using MediatR;

namespace Application.Attractions.Create;

public record CreateAttractionCommand(
    string Name,
    string Description,
    string Country
) : IRequest<ErrorOr<Unit>>;
