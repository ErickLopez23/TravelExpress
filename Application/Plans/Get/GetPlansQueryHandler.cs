using Application.Plans.DTOs;
using Domain.Plans;
using ErrorOr;
using MediatR;

namespace Application.Plans.Get;

public sealed class GetPlansQueryHandler : IRequestHandler<GetPlansQuery, ErrorOr<IReadOnlyList<PlanReponse>>>
{
    private readonly IPlanRepository _planRepository;

    public GetPlansQueryHandler(IPlanRepository planRepository)
    {
        _planRepository = planRepository;
    }

    public async Task<ErrorOr<IReadOnlyList<PlanReponse>>> Handle(GetPlansQuery request, CancellationToken cancellationToken)
    {
        var plans = await _planRepository.Get(
            request.Departure,
            request.Return,
            request.StartPrice,
            request.EndPrice,
            request.Country);

        return plans.Select(x => new PlanReponse(
           x.Id.Value,
           x.Name,
           x.Description,
           x.Departure.ToShortDateString(),
           x.Return.ToShortDateString(),
           x.Price,
           x.PlanItems
               .Select(pi =>
                   new PlanItemReponse(
                       pi.Id.Value,
                       pi.Attraction.Name,
                       pi.Attraction.Country))
               .ToList()
           ))
           .ToList();
    }
}
