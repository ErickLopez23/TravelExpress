using Domain.Plans;
using Domain.Primitives;

namespace Domain.Bookings;

public sealed class Booking : AggregateRoot
{
    public BookingId Id { get; private set; }
    public PlanId PlanId { get; private set; }
    public Customer Customer { get; private set; }

    private Booking()
    {
        
    }

    public Booking(BookingId id, PlanId planId, Customer customer)
    {
        Id = id;
        PlanId = planId;
        Customer = customer;
    }
}
