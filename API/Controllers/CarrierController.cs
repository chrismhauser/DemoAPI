using Data.Requests._Carrier;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarrierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CarrierController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCarriersQuery();
            var result = await _mediator.Send(query);
            return result is not null ? Ok(result) : NotFound();
        }

        // GET api/<CarrierController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetCarrierQuery(id);
            var result = await _mediator.Send(query);
            return result is not null ? Ok(result) : NotFound();
        }

        // POST api/<CarrierController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            var query = new InsertCarrierCommand(value);
            var result = await _mediator.Send(query);
            return result ? Ok(result) : BadRequest();
        }

        // PUT api/<CarrierController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            var query = new UpdateCarrierCommand(id, value);
            var result = await _mediator.Send(query);
            return result ? Ok(result) : BadRequest();
        }

        // DELETE api/<CarrierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
