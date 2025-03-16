using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.UseCases;
using Pacagroup.Ecommerce.Transversal.Common;
using Swashbuckle.AspNetCore.Annotations;

namespace Pacagroup.Ecommerce.Services.WebApi.Controllers.v2
{

    [Authorize]
    [EnableRateLimiting("fixedWindow")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [SwaggerTag("Get Categories of Products")]

    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesApplication _categoriesApplication;

        public CategoriesController(ICategoriesApplication categoriesApplication)
        {
            _categoriesApplication = categoriesApplication;
        }

        [HttpGet("GetAll")]
        [SwaggerOperation(Summary = "Get Categories",
                          Description = "This endpoint will return all categories",
                          OperationId = "GetAll",
                          Tags = new string[] { "GetAll" })]
        [SwaggerResponse(200, "List of Categories", typeof(Response<IEnumerable<CategoryDto>>))]
        [SwaggerResponse(404, "Notfound Categories")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _categoriesApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}
