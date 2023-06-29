namespace Application.Bookings.DTOs;

public record BookingResponse(
    Guid Id,
    string CustomerName,
    string CustomerPhone,
    string CustomerEmail,
    string PlanName,
    string Departure,
    string Return
);
