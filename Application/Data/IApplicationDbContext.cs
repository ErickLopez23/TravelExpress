using Domain.Attractions;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Attraction> Attractions { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
