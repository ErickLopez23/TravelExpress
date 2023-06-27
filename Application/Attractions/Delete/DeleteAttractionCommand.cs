using ErrorOr;
using MediatR;

namespace Application.Attractions.Delete;

public record DeleteAttractionCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
