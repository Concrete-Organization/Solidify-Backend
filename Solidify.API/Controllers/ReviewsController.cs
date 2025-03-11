using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.E_Commerce.CartItems.Commands.AddCartItem;
using Solidify.Application.E_Commerce.Products.Commands.CreateProduct;
using Solidify.Application.E_Commerce.Reviews.Commands.CreateReview;
using Solidify.Application.E_Commerce.Reviews.Dtos;

namespace Solidify.API.Controllers
{

    public class ReviewsController(IMediator mediator) : BaseController(mediator)
    {
        [Authorize]
        [HttpPost("{productId}")]
        public async Task<IActionResult> AddProductReview([FromRoute]CreateReviewCommand command, [FromBody]CreateReviewDto dto)
        {
            command.Message = dto.Message;
            command.UserRate = dto.UserRate;
            return await HandleCommand(command);
        }
    }
}
