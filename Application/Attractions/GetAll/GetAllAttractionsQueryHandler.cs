using Application.Attractions.DTOs;
using Domain.Attractions;
using ErrorOr;
using MediatR;

namespace Application.Attractions.GetAll;

internal sealed class GetAllAttractionsQueryHandler : IRequestHandler<GetAllAttractionQuery, ErrorOr<IReadOnlyList<AttractionResponse>>>
{
    private readonly IAttractionRepository _attractionRepository;

    public GetAllAttractionsQueryHandler(IAttractionRepository attractionRepository)
    {
        _attractionRepository = attractionRepository;
    }

    public async Task<ErrorOr<IReadOnlyList<AttractionResponse>>> Handle(GetAllAttractionQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Attraction> attractions = await _attractionRepository.GetAllAsync();


        return attractions
            .Select(a => new AttractionResponse(
                a.Id.Value, 
                a.Name, 
                a.Description, 
                a.Country))
            .ToList();
    }
}
