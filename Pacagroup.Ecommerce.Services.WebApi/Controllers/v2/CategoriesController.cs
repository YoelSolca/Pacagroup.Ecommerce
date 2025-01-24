using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Pacagroup.Ecommerce.Application.Interface.UseCases;

namespace Pacagroup.Ecommerce.Services.WebApi.Controllers.v2
{

    [Authorize]
    [EnableRateLimiting("fixedWindow")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]

    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesApplication _categoriesApplication;
        
        public CategoriesController(ICategoriesApplication categoriesApplication)
        {
            _categoriesApplication = categoriesApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _categoriesApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}
