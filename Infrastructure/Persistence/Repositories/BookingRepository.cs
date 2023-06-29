using Domain.Bookings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly ApplicationDbContext _context;

    public BookingRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Booking booking) =>
        _context.Add(booking);

    public async Task<IReadOnlyList<Booking>> GetAllAsync() =>
        await _context.Bookings
            .ToListAsync();

    public async Task<Booking?> GetByIdAsync(BookingId id) =>
        await _context.Bookings
            .SingleOrDefaultAsync(a => a.Id == id);
}
