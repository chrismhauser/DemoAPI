using Data.Requests._PolicyType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PolicyTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PolicyTypeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllPolicyTypesQuery();
            var result = await _mediator.Send(query);
            return result is not null ? Ok(result) : NotFound();
        }

        // GET api/<PolicyTypeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetPolicyTypeQuery(id);
            var result = await _mediator.Send(query);
            return result is not null ? Ok(result) : NotFound();
        }

        // POST api/<PolicyTypeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            var query = new InsertPolicyTypeCommand(value);
            var result = await _mediator.Send(query);
            return result ? Ok(result) : BadRequest();
        }

        // PUT api/<PolicyTypeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            var query = new UpdatePolicyTypeCommand(id, value);
            var result = await _mediator.Send(query);
            return result ? Ok(result) : BadRequest();
        }

        // DELETE api/<PolicyTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
