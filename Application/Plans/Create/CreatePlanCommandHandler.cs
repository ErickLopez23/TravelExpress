using Domain.Attractions;
using Domain.Plans;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Plans.Create;

internal sealed class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand, ErrorOr<Unit>>
{
    private readonly IPlanRepository _planRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePlanCommandHandler(IPlanRepository planRepository, IUnitOfWork unitOfWork)
    {
        _planRepository = planRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
    {
        if (request.Return < request.Departure)
            return Error.Validation("DateNotMatch.Validation", "Dates do not match");

        var plan = new Plan(
            new PlanId(Guid.NewGuid()),
            request.Name,
            request.Description,
            request.Departure,
            request.Return,
            request.Price);

        _planRepository.Add(plan);

        foreach (var planItem in request.PlanItems)
        {
            var item = new PlanItem(
                new PlanItemId(Guid.NewGuid()),
                plan.Id,
                new AttractionId(planItem.AttractionId));

            plan.AddPlanItem(item);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
