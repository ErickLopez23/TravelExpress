using Domain.Bookings;
using Domain.Plans;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Bookings.Create;

public sealed class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, ErrorOr<Unit>>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBookingCommandHandler(IBookingRepository bookingRepository, IUnitOfWork unitOfWork)
    {
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        if (Customer.Create(request.CustomerName, request.CustomerPhone, request.CustomerEmail) is not Customer customer)
            return Error.Validation("CreateCustomerError.Validation", "Oops! customer is not valid");

        var booking = new Booking(
            new BookingId(Guid.NewGuid()),
            new PlanId(request.PlanId),
            customer);

        _bookingRepository.Add(booking);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
