using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.UseCases;
using Pacagroup.Ecommerce.Application.UseCases.Customers;

namespace Pacagroup.Ecommerce.Services.WebApi.Controllers.v2
{
    [Authorize]
    [EnableRateLimiting("fixedWindow")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountApplication _discountApplication;

        public DiscountsController(IDiscountApplication discountApplication)
        {
            _discountApplication = discountApplication;
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] DiscountDto discountDto)
        {
            if (discountDto == null)
                return BadRequest();

            var response = await _discountApplication.Create(discountDto);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DiscountDto discountDto)
        {
            var customerDtoExists = await _discountApplication.Get(id);

            if (customerDtoExists.Data == null)
                return NotFound(customerDtoExists.Message);

            if (discountDto == null)
                return BadRequest();

            var response = await _discountApplication.Update(discountDto);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _discountApplication.Delete(id);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _discountApplication.Get(id);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _discountApplication.GetAll();
           
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
