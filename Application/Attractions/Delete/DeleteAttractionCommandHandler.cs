using Domain.Attractions;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Attractions.Delete;

internal sealed class DeleteAttractionCommandHandler : IRequestHandler<DeleteAttractionCommand, ErrorOr<Unit>>
{
    private readonly IAttractionRepository _attractionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAttractionCommandHandler(IAttractionRepository attractionRepository, IUnitOfWork unitOfWork)
    {
        _attractionRepository = attractionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteAttractionCommand request, CancellationToken cancellationToken)
    {
        var attraction = await _attractionRepository.GetByIdAsync(new AttractionId(request.Id));

        if (attraction is null)
            return Error.NotFound("AttractionNotFound", $"The attraction with id {request.Id} was not found");

        _attractionRepository.Remove(attraction);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
