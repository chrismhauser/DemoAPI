using Data.Requests._Policy;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using API.RequestModels;

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
        public async Task<IActionResult> Get()
        {
            var query = new GetAllPoliciesQuery();
            var result = await _mediator.Send(query);
            return result is not null ? Ok(result) : NotFound();
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
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePolicyRequest request)
        {
            var query = new UpdatePolicyCommand(
                id,
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

        // DELETE api/<PolicyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
