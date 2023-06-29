using ErrorOr;
using MediatR;

namespace Application.Bookings.Create;

public record CreateBookingCommand(
    Guid PlanId,
    string CustomerName,
    string CustomerPhone,
    string CustomerEmail
) : IRequest<ErrorOr<Unit>>;
