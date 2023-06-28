using Application.Plans.DTOs;
using ErrorOr;
using MediatR;

namespace Application.Plans.GetById;

public record GetPlanByIdQuery(Guid Id) : IRequest<ErrorOr<PlanReponse>>;
