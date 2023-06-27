using Domain.Attractions;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Attractions.Create;

internal sealed class CreateAttractionCommandHandler : IRequestHandler<CreateAttractionCommand, ErrorOr<Unit>>
{
    private readonly IAttractionRepository _attractionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAttractionCommandHandler(IAttractionRepository attractionRepository, IUnitOfWork unitOfWork)
    {
        _attractionRepository = attractionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(CreateAttractionCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Name))
            return Error.Validation("AttractionName.Validation", "Attraction name is invalid");

        var attraction = new Attraction(
            new AttractionId(Guid.NewGuid()),
            request.Name,
            request.Description,
            request.Country
        );

        _attractionRepository.Add(attraction);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
