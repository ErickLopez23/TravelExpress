using Application.Attractions.DTOs;
using Domain.Attractions;
using ErrorOr;
using MediatR;

namespace Application.Attractions.GetById;

internal sealed class GetAttractionByIdQueryHandler : IRequestHandler<GetAttractionByIdQuery, ErrorOr<AttractionResponse>>
{
    private readonly IAttractionRepository _attractionRepository;

    public GetAttractionByIdQueryHandler(IAttractionRepository attractionRepository)
    {
        _attractionRepository = attractionRepository;
    }

    public async Task<ErrorOr<AttractionResponse>> Handle(GetAttractionByIdQuery request, CancellationToken cancellationToken)
    {
        var attraction = await _attractionRepository.GetByIdAsync(new AttractionId(request.Id));

        if (attraction is null)
            return Error.NotFound("AttractionNotFound", $"The attraction with id {request.Id} was not found");

        return new AttractionResponse(
            attraction.Id.Value,
            attraction.Name,
            attraction.Description,
            attraction.Country);
    }
}
