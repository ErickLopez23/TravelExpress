using Application.Plans.DTOs;
using ErrorOr;
using MediatR;

namespace Application.Plans.GetAll;

public record GetAllPlansQuery : IRequest<ErrorOr<IReadOnlyList<PlanReponse>>>;
