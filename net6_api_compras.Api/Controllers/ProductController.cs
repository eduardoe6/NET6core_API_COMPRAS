using Microsoft.AspNetCore.Mvc;
using net6_api_compras.Application.DTOs;
using net6_api_compras.Application.Services.Interfaces;

namespace net6_api_compras.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] ProductDTO productDTO)
        {
            var result = await _productService.CreateAsync(productDTO);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ProductDTO productDTO)
        {
            var result = await _productService.UpdateAsync(productDTO);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            var result = await _productService.RemoveAsync(id);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var result = await _productService.GetAllAsync();

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var result = await _productService.GetAsync(id);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result);
        }
    }
}
