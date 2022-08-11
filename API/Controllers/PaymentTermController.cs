﻿using Data.Commands;
using Data.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTermController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentTermController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PaymentTermController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PaymentTermController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetPaymentTermQuery(id);
            var result = await _mediator.Send(query);
            return result is not null ? Ok(result) : NotFound();
        }

        // POST api/<PaymentTermController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            var query = new InsertPaymentTermCommand(value);
            var result = await _mediator.Send(query);
            return result ? Ok(result) : BadRequest();
        }

        // PUT api/<PaymentTermController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PaymentTermController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
