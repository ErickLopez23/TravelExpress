using Application.Bookings.Create;
using Application.Bookings.GetAll;
using Application.Bookings.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class BookingsController : ApiController
    {
        private readonly ISender _mediator;

        public BookingsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bookingsResult = await _mediator.Send(new GetAllBookingsQuery());

            return bookingsResult.Match(
                bookings => Ok(bookings),
                errors => Problem(errors));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var bookingResult = await _mediator.Send(new GetBookingByIdQuery(id));

            return bookingResult.Match(
                booking => Ok(booking),
                errors => Problem(errors));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookingCommand command)
        {
            var createBookingResult = await _mediator.Send(command);

            return createBookingResult.Match(
                booking => Ok(booking),
                errors => Problem(errors));
        }
    }
}
