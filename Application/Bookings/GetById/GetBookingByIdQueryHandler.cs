using Application.Bookings.DTOs;
using Domain.Bookings;
using ErrorOr;
using MediatR;

namespace Application.Bookings.GetById;

internal sealed class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, ErrorOr<BookingResponse>>
{
    private readonly IBookingRepository _bookingRepository;

    public GetBookingByIdQueryHandler(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<ErrorOr<BookingResponse>> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(
            new BookingId(request.Id));

        if (booking is null)
            return Error.NotFound("", "");

        return new BookingResponse(
            booking.Id.Value,
            booking.Customer.Name,
            booking.Customer.Phone,
            booking.Customer.Email,
            booking.Plan.Name,
            booking.Plan.Departure.ToShortDateString(),
            booking.Plan.Return.ToShortDateString());
    }
}
