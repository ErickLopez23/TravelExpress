namespace Domain.Plans;

public interface IPlanRepository
{
    Task<IReadOnlyList<Plan>> Get(DateTime? departure, DateTime? @return, decimal? startPrice, decimal? endPrice, string? country);
    Task<IReadOnlyList<Plan>> GetAllAsync();
    Task<Plan?> GetByIdAsync(PlanId id);
    void Add(Plan plan);
    void Update(Plan plan);
    void Remove(Plan plan);

    Task<PlanItem?> GetPlanItemByIdAsync(PlanItemId id);
    void AddPlanItem(PlanItem planItem);
    void RemovePlanItem(PlanItem planItem);
}
