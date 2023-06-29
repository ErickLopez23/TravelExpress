using Application.Bookings.DTOs;
using ErrorOr;
using MediatR;

namespace Application.Bookings.GetAll;

public record GetAllBookingsQuery : IRequest<ErrorOr<IReadOnlyList<BookingResponse>>>;
