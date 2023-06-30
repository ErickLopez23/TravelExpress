using Application.Plans.AddPlanItem;
using Application.Plans.Create;
using Application.Plans.Delete;
using Application.Plans.Get;
using Application.Plans.GetAll;
using Application.Plans.GetById;
using Application.Plans.RemovePlanItem;
using Application.Plans.Update;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PlansController : ApiController
    {
        private readonly ISender _mediator;

        public PlansController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Get(DateTime? departure, DateTime? @return, decimal? startPrice, decimal? endPrice, string? country)
        {
            var query = new GetPlansQuery(departure, @return, startPrice, endPrice, country);

            var planResult = await _mediator.Send(query);

            return planResult.Match(
               plans => Ok(plans),
               errors => Problem(errors));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var planResult = await _mediator.Send(new GetAllPlansQuery());

            return planResult.Match(
                plans => Ok(plans),
                errors => Problem(errors));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var planResult = await _mediator.Send(new GetPlanByIdQuery(id));

            return planResult.Match(
                plan => Ok(plan),
                errors => Problem(errors));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePlanCommand command)
        {
            var createPlanResult = await _mediator.Send(command);

            return createPlanResult.Match(
                plan => Ok(plan),
                errors => Problem(errors));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePlanCommand command)
        {
            if (command.Id != id)
            {
                List<Error> errors = new()
            {
                Error.Validation("PlanUpdateInvalid", $"The request Id {command.Id} does not match with the url Id. {id}")
            };
                return Problem(errors);
            }

            var updatePlanResult = await _mediator.Send(command);

            return updatePlanResult.Match(
                plan => NoContent(),
                errors => Problem(errors));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, [FromBody] DeletePlanCommand command)
        {
            var deletePlanResult = await _mediator.Send(command);

            return deletePlanResult.Match(
                plan => NoContent(),
                errors => Problem(errors));
        }

        [HttpPost("/AddPlanItem")]
        public async Task<IActionResult> AddPlanItem([FromBody] AddPlanItemCommand command)
        {
            var addPlanItemResult = await _mediator.Send(command);

            return addPlanItemResult.Match(
                planItem => Ok(planItem),
                errors => Problem(errors));
        }

        [HttpDelete("/RemovePlanItem/{id:guid}")]
        public async Task<IActionResult> RemovePlanItem(Guid id, [FromBody] RemovePlanItemCommand command)
        {
            var removePlanItemResult = await _mediator.Send(command);

            return removePlanItemResult.Match(
                planItem => Ok(planItem),
                errors => Problem(errors));
        }
    }
}
