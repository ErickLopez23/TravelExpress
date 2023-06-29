using Application.Attractions.Create;
using Domain.Attractions;
using Domain.Primitives;

namespace Application.Attractions.UnitTests.Create
{
    public class CreateAttractionCommandHandlerUnitTests
    {
        private readonly Mock<IAttractionRepository> _mockAttractionRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        private readonly CreateAttractionCommandHandler _handler;

        public CreateAttractionCommandHandlerUnitTests()
        {
            _mockAttractionRepository = new Mock<IAttractionRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();

            _handler = new CreateAttractionCommandHandler(_mockAttractionRepository.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task HandleCreateAttraction_WhenNameIsInvalid_ShouldReturnValidationError()
        {
            // arrange
            // configura los parametros de entrada

            var command = new CreateAttractionCommand("", "Hello", "El Salvador");

            // act
            // se ejecuta el metodo a probar

            var result = await _handler.Handle(command, default);

            // assert
            // se verifica los datos de retorno

            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            result.FirstError.Code.Should().Be("AttractionName.Validation");
        }

        [Fact]
        public async Task HandleCreateAttraction_WhenCountryIsInvalid_ShouldReturnValidationError()
        {
            // arrange

            var command = new CreateAttractionCommand("San Salvador", "Hello", "");

            // act

            var result = await _handler.Handle(command, default);

            // assert

            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            result.FirstError.Code.Should().Be("AttractionCountry.Validation");
        }
    }
}
 