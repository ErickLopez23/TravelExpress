using ErrorOr;
using MediatR;

namespace Application.Plans.Delete;

public record DeletePlanCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
