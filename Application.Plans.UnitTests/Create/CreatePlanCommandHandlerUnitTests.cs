using Application.Plans.Create;
using Domain.Plans;
using Domain.Primitives;

namespace Application.Plans.UnitTests.Create
{
    public class CreatePlanCommandHandlerUnitTests
    {
        private readonly Mock<IPlanRepository> _mockPlanRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        private readonly CreatePlanCommandHandler _handler;

        public CreatePlanCommandHandlerUnitTests()
        {
            _mockPlanRepository = new Mock<IPlanRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _handler = new CreatePlanCommandHandler(_mockPlanRepository.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task HandleCreatePlan_WhenDatesIsInvalid_ShouldReturnValidationError()
        {
            // arrange

            var command = new CreatePlanCommand(
                "Viajando por el mundo",
                "Something",
                new DateTime(2023, 7, 1),
                new DateTime(2023, 6, 20),
                0, new List<PlanItemDto>());

            // act

            var result = await _handler.Handle(command, default);

            // assert

            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            result.FirstError.Code.Should().Be("DateNotMatch.Validation");
        }
    }
}
