using Microsoft.AspNetCore.Mvc;
using net6_api_compras.Application.DTOs;
using net6_api_compras.Application.Services;
using net6_api_compras.Application.Services.Interfaces;
using net6_api_compras.Domain.Validations;

namespace net6_api_compras.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] PurchaseDTO purchaseDTO)
        {
            try
            {
                var result = await _purchaseService.CreateAsync(purchaseDTO);

                if (result.IsSuccess) return Ok(result);

                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                return BadRequest(ResultService.Fail(ex.Message));
            }
        }
    }
}
