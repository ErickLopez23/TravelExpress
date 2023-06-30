using Application.Plans.DTOs;
using ErrorOr;
using MediatR;

namespace Application.Plans.Get;

public record GetPlansQuery(
    DateTime? Departure,
    DateTime? Return,
    decimal? StartPrice,
    decimal? EndPrice,
    string? Country
) : IRequest<ErrorOr<IReadOnlyList<PlanReponse>>>;
