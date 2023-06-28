using Domain.Plans;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Plans.Delete;

internal sealed class DeletePlanCommandHandler : IRequestHandler<DeletePlanCommand, ErrorOr<Unit>>
{
    private readonly IPlanRepository _planRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePlanCommandHandler(IPlanRepository planRepository, IUnitOfWork unitOfWork)
    {
        _planRepository = planRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(DeletePlanCommand request, CancellationToken cancellationToken)
    {
        var plan = await _planRepository.GetByIdAsync(new PlanId(request.Id));

        if (plan is null)
            return Error.NotFound("PlanNotFound.NotFound", "Plan not found");

        _planRepository.Remove(plan);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
