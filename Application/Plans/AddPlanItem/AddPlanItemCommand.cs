using ErrorOr;
using MediatR;

namespace Application.Plans.AddPlanItem;

public record AddPlanItemCommand(Guid PlanId, Guid AttractionId) : IRequest<ErrorOr<Unit>>;
