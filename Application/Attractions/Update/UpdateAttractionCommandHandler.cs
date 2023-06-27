using Domain.Attractions;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Attractions.Update;

internal sealed class UpdateAttractionCommandHandler : IRequestHandler<UpdateAttractionCommand, ErrorOr<Unit>>
{
    private readonly IAttractionRepository _attractionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAttractionCommandHandler(IAttractionRepository attractionRepository, IUnitOfWork unitOfWork)
    {
        _attractionRepository = attractionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateAttractionCommand request, CancellationToken cancellationToken)
    {
        var attraction = await _attractionRepository.GetByIdAsync(new AttractionId(request.Id));

        if (attraction is null)
            return Error.NotFound("AttractionNotFound", $"The attraction with id {request.Id} was not found");

        attraction.Update(request.Name, request.Description, request.Country);

        _attractionRepository.Update(attraction);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
