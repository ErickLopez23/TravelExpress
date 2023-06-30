using ErrorOr;
using MediatR;

namespace Application.Plans.Create;

public record CreatePlanCommand(
    string Name,
    string Description,
    DateTime Departure,
    DateTime Return,
    decimal Price,
    List<Guid> PlanItems
) : IRequest<ErrorOr<Unit>>;
