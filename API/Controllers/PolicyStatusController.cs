using Data.Requests._PolicyStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyStatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PolicyStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PolicyStatusController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllPolicyStatusesQuery();
            var result = await _mediator.Send(query);
            return result is not null ? Ok(result) : NotFound();
        }

        // GET api/<PolicyStatusController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetPolicyStatusQuery(id);
            var result = await _mediator.Send(query);
            return result is not null ? Ok(result) : NotFound();
        }

        // POST api/<PolicyStatusController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            var query = new InsertPolicyStatusCommand(value);
            var result = await _mediator.Send(query);
            return result ? Ok(result) : BadRequest();
        }

        // PUT api/<PolicyStatusController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            var query = new UpdatePolicyStatusCommand(id, value);
            var result = await _mediator.Send(query);
            return result ? Ok(result) : BadRequest();
        }

        // DELETE api/<PolicyStatusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
