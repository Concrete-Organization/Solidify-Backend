using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.E_Commerce.Categories.Queries.GetAllCategories;
using System.Runtime.InteropServices;

namespace Solidify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IMediator mediator) : BaseController(mediator)
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await HandleCommand(new GetAllCategoriesQuery());
        }

    }
}
