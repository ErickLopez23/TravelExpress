using Domain.Attractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class AttractionRepository : IAttractionRepository
{
    private readonly ApplicationDbContext _context;

    public AttractionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Attraction attraction) =>
        _context.Attractions.Add(attraction);

    public async Task<IReadOnlyList<Attraction>> GetAllAsync() =>
        await _context.Attractions.ToListAsync();

    public async Task<Attraction?> GetByIdAsync(AttractionId id) =>
        await _context.Attractions.SingleOrDefaultAsync(a => a.Id == id);

    public void Remove(Attraction attraction) =>
        _context.Attractions.Remove(attraction);

    public void Update(Attraction attraction) =>
        _context.Attractions.Update(attraction);
}
