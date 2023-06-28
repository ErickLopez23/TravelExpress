using ErrorOr;
using MediatR;

namespace Application.Plans.Update;

public record UpdatePlanCommand(
    Guid Id,
    string Name,
    string Description,
    DateTime Departure,
    DateTime Return,
    decimal Price
) : IRequest<ErrorOr<Unit>>;
