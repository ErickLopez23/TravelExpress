using Domain.Plans;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Plans.RemovePlanItem;

internal sealed class RemovePlanItemCommandHandler : IRequestHandler<RemovePlanItemCommand, ErrorOr<Unit>>
{
    private readonly IPlanRepository _planRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemovePlanItemCommandHandler(IPlanRepository planRepository, IUnitOfWork unitOfWork)
    {
        _planRepository = planRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(RemovePlanItemCommand request, CancellationToken cancellationToken)
    {
        var planItem = await _planRepository.GetPlanItemByIdAsync(new PlanItemId(request.Id));

        if (planItem is null)
            return Error.NotFound("PlanItemNotFound.NotFound", "PlanItem not found");

        _planRepository.RemovePlanItem(planItem);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
