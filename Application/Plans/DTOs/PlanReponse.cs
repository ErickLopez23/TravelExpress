namespace Application.Plans.DTOs;

public record PlanReponse(
    Guid Id,
    string Name,
    string Description,
    string Departure,
    string Return,
    decimal Price,
    List<PlanItemReponse> PlanItems
);

public record PlanItemReponse(
    Guid Id,
    string Name,
    string Country);