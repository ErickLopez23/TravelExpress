namespace Domain.Bookings;

public interface IBookingRepository
{
    Task<IReadOnlyList<Booking>> GetAllAsync(); 
    Task<Booking?> GetByIdAsync(BookingId id); 
    void Add(Booking booking);
}
