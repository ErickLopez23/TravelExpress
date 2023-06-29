using Application.Bookings.Create;
using Domain.Bookings;
using Domain.Primitives;

namespace Application.Bookings.UnitTests.Create
{
    public class CreateBookingCommandHandlerUnitTests
    {
        private readonly Mock<IBookingRepository> _mockBookingRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        private readonly CreateBookingCommandHandler _handler;

        public CreateBookingCommandHandlerUnitTests()
        {
            _mockBookingRepository = new Mock<IBookingRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();

            _handler = new CreateBookingCommandHandler(_mockBookingRepository.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task HandleCreateBooking_WhenCustomerIsNotValid_ShouldReturnErrorValidation()
        {
            // arrage

            var command = new CreateBookingCommand(
                Guid.NewGuid(),
                "", "", "");

            // act

            var result = await _handler.Handle(command, default);

            // assert

            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            result.FirstError.Code.Should().Be("CreateCustomerError.Validation");
        }
    }
}
