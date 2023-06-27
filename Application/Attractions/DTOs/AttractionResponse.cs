namespace Application.Attractions.DTOs;

public record AttractionResponse(
    Guid Id,
    string Name,
    string Description,
    string Country);
