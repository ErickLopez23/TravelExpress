using Application.Bookings.DTOs;
using Domain.Bookings;
using ErrorOr;
using MediatR;

namespace Application.Bookings.GetAll;

internal sealed class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingsQuery, ErrorOr<IReadOnlyList<BookingResponse>>>
{
    private readonly IBookingRepository _bookingRepository;

    public GetAllBookingsQueryHandler(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<ErrorOr<IReadOnlyList<BookingResponse>>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
    {
        var bookings = await _bookingRepository.GetAllAsync();

        return bookings.Select(b =>
            new BookingResponse(
                b.Id.Value,
                b.Customer.Name,
                b.Customer.Phone,
                b.Customer.Email, ""))
            .ToList();
    }
}
