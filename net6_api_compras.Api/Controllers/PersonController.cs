using Microsoft.AspNetCore.Mvc;
using net6_api_compras.Application.DTOs;
using net6_api_compras.Application.Services.Interfaces;

namespace net6_api_compras.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonDTO personDTO)
        {
            var result = await _personService.CreateAsync(personDTO);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] PersonDTO personDTO)
        {
            var result = await _personService.UpdateAsync(personDTO);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            var result = await _personService.RemoveAsync(id);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var result = await _personService.GetAllAsync();

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var result = await _personService.GetAsync(id);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result);
        }
    }

}
