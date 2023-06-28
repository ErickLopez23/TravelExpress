using ErrorOr;
using MediatR;

namespace Application.Plans.RemovePlanItem;

public record RemovePlanItemCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
