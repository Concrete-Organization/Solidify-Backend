using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.E_Commerce.Brands.Commands.AddBrand;
using Solidify.Application.E_Commerce.ShippingAddresses.Commands;

namespace Solidify.API.Controllers
{

    public class ShippingAddressController(IMediator mediator) : BaseController(mediator)
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateShippingAddressCommand command)
        {
            return await HandleCommand(command);
        }

    }
}
