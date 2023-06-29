using Domain.Attractions;
using Domain.Bookings;
using Domain.Plans;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Attraction> Attractions { get; set; }
    DbSet<Plan> Plans { get; set; }
    DbSet<PlanItem> PlanItems { get; set; }
    DbSet<Booking> Bookings { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
