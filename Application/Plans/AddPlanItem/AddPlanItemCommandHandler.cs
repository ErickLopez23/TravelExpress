using Domain.Attractions;
using Domain.Plans;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Plans.AddPlanItem;

internal sealed class AddPlanItemCommandHandler : IRequestHandler<AddPlanItemCommand, ErrorOr<Unit>>
{
    private readonly IPlanRepository _planRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddPlanItemCommandHandler(IPlanRepository planRepository, IUnitOfWork unitOfWork)
    {
        _planRepository = planRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(AddPlanItemCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.PlanId.ToString()))
            return Error.Validation("AddPlanItemValidation", "Oops! invalid planid");

        if (string.IsNullOrEmpty(request.AttractionId.ToString()))
            return Error.Validation("AddPlanItemValidation", "Oops! invalid attractionid");

        var item = new PlanItem(
            new PlanItemId(Guid.NewGuid()),
            new PlanId(request.PlanId),
            new AttractionId(request.AttractionId));

        _planRepository.AddPlanItem(item);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}
