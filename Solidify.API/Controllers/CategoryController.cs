using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.E_Commerce.Categories.Commands;
using Solidify.Application.E_Commerce.Categories.Commands.DeleteCategory;
using Solidify.Application.E_Commerce.Categories.Queries;
using Solidify.Application.E_Commerce.Categories.Query.GetAllCategories;

namespace Solidify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IMediator mediator) : BaseController(mediator)
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoriesQuery query)
        {
            return await HandleCommand(query);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id, [FromQuery] GetCategoryQuery query)
        {
            query.Id = Id;
            return await HandleCommand(query);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategotyCommand command)
        {
            return await HandleCommand(command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return await HandleCommand(new DeleteCategoryCommand(id));
        }
    }
}
