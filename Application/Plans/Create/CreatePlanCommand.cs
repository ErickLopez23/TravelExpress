using ErrorOr;
using MediatR;

namespace Application.Plans.Create;

public record CreatePlanCommand(
    string Name,
    string Description,
    DateTime Departure,
    DateTime Return,
    decimal Price,
    List<PlanItemDto> PlanItems
) : IRequest<ErrorOr<Unit>>;

public record PlanItemDto(
    Guid AttractionId);
