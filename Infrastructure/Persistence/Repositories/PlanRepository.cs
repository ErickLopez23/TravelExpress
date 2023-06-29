using Domain.Plans;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class PlanRepository : IPlanRepository
{
    private readonly ApplicationDbContext _context;

    public PlanRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Plan plan) =>
        _context.Plans.Add(plan);

    public void AddPlanItem(PlanItem planItem) => 
        _context.PlanItems.Add(planItem);

    public async Task<IReadOnlyList<Plan>> GetAllAsync() =>
        await _context.Plans
            .Include(x => x.PlanItems)
            .ThenInclude(pi => pi.Attraction)
            .ToListAsync();

    public async Task<Plan?> GetByIdAsync(PlanId id) =>
        await _context.Plans
            .Include(x => x.PlanItems)
            .ThenInclude(pi => pi.Attraction)
            .SingleOrDefaultAsync(x => x.Id == id);

    public async Task<PlanItem?> GetPlanItemByIdAsync(PlanItemId id) =>
        await _context.PlanItems.FirstOrDefaultAsync(x => x.Id == id);

    public void Remove(Plan plan) =>
        _context.Plans.Remove(plan);

    public void RemovePlanItem(PlanItem planItem) =>
        _context.PlanItems.Remove(planItem);

    public void Update(Plan plan) =>
        _context.Plans.Update(plan);
}
