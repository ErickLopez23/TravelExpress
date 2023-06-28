using Application.Plans.DTOs;
using Domain.Plans;
using ErrorOr;
using MediatR;

namespace Application.Plans.GetById;

internal sealed class GetPlanByIdQueryHandler : IRequestHandler<GetPlanByIdQuery, ErrorOr<PlanReponse>>
{
    private readonly IPlanRepository _planRepository;

    public GetPlanByIdQueryHandler(IPlanRepository planRepository)
    {
        _planRepository = planRepository;
    }

    public async Task<ErrorOr<PlanReponse>> Handle(GetPlanByIdQuery request, CancellationToken cancellationToken)
    {
        var plan = await _planRepository.GetByIdAsync(new PlanId(request.Id));

        if (plan is null)
            return Error.NotFound("PlanNotFound.NotFound", "Plan not found");

        var items = plan.PlanItems.Select(x => new PlanItemReponse(
            x.Id.Value,
            "",
            ""))
            .ToList();

        return new PlanReponse(
            plan.Id.Value,
            plan.Name,
            plan.Description,
            plan.Departure,
            plan.Return,
            plan.Price,
            items);
    }
}
