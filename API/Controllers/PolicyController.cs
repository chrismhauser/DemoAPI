using API.Requests;
using Data.Commands;
using Data.Handlers;
using Data.Models;
using Data.Queries;
using Microsoft.AspNetCore.Mvc;
using MediatR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PolicyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PolicyController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PolicyController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetPolicyQuery(id);
            var result = await _mediator.Send(query);
            return result is not null ? Ok(result) : NotFound();
        }

        // POST api/<PolicyController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertPolicyRequest request)
        {
            var query = new InsertPolicyCommand(
                "ABCD-1234",
                request.EffectiveDate,
                request.PolicyTypeId,
                request.PolicyStatusId,
                request.CarrierId,
                request.PaymentTermId
                );
            var result = await _mediator.Send(query);
            return result ? Ok(result) : BadRequest();
        }

        // PUT api/<PolicyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PolicyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
