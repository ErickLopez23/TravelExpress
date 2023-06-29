using Application.Plans.DTOs;
using Domain.Plans;
using ErrorOr;
using MediatR;

namespace Application.Plans.GetAll;

internal sealed class GetAllPlansQueryHandler : IRequestHandler<GetAllPlansQuery, ErrorOr<IReadOnlyList<PlanReponse>>>
{
    private readonly IPlanRepository _planRepository;

    public GetAllPlansQueryHandler(IPlanRepository planRepository)
    {
        _planRepository = planRepository;
    }

    public async Task<ErrorOr<IReadOnlyList<PlanReponse>>> Handle(GetAllPlansQuery request, CancellationToken cancellationToken)
    {
        var plans = await _planRepository.GetAllAsync();

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
