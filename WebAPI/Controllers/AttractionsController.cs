using Application.Attractions.Create;
using Application.Attractions.Delete;
using Application.Attractions.GetAll;
using Application.Attractions.GetById;
using Application.Attractions.Update;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
public class AttractionsController : ApiController
{
    private readonly ISender _mediator;

    public AttractionsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var attractionsResult = await _mediator.Send(new GetAllAttractionQuery());

        return attractionsResult.Match(
            attractions => Ok(attractions), 
            errors => Problem(errors));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var attractionsResult = await _mediator.Send(new GetAttractionByIdQuery(id));

        return attractionsResult.Match(
            attraction => Ok(attraction),
            errors => Problem(errors));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAttractionCommand command)
    {
        var createAttractionResult = await _mediator.Send(command);

        return createAttractionResult.Match(
            attraction => Ok(attraction),
            errors => Problem(errors));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAttractionCommand command)
    {
        if (command.Id != id)
        {
            List<Error> errors = new()
            {
                Error.Validation("AttractionUpdateInvalid", $"The request Id {command.Id} does not match with the url Id. {id}")
            };
            return Problem(errors);
        }

        var updateAttractionResult = await _mediator.Send(command);

        return updateAttractionResult.Match(
            attraction => NoContent(),
            errors => Problem(errors));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remove(Guid id, [FromBody] DeleteAttractionCommand command)
    {
        var deleteAttractionResult = await _mediator.Send(command);

        return deleteAttractionResult.Match(
            attraction => NoContent(),
            errors => Problem(errors));
    }
}
