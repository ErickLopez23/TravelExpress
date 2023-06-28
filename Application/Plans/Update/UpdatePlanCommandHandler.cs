using Domain.Plans;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Plans.Update;

internal sealed class UpdatePlanCommandHandler : IRequestHandler<UpdatePlanCommand, ErrorOr<Unit>>
{
    private readonly IPlanRepository _planRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePlanCommandHandler(IPlanRepository planRepository, IUnitOfWork unitOfWork)
    {
        _planRepository = planRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
    {
        var plan = await _planRepository.GetByIdAsync(new PlanId(request.Id));

        if (plan is null)
            return Error.NotFound("PlanNotFound.NotFound", "Plan not found");

        plan.Update(
            request.Name,
            request.Description,
            request.Departure,
            request.Return,
            request.Price);

        _planRepository.Update(plan);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
