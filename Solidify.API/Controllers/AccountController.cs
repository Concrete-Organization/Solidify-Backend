using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.Accounts.Commands.Login;
using Solidify.Application.Accounts.Commands.Register;
using Solidify.Application.Accounts.Commands.ResetPassword;
using Solidify.Application.Accounts.Commands.SendOtp;
using Solidify.Application.Accounts.Commands.VerifyOtp;
using Solidify.Application.Common.Dtos;

namespace Solidify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController(IMediator mediator) : ControllerBase
    {

        private async Task<IActionResult> HandleCommand<TCommand>(TCommand command) where TCommand : IRequest<GeneralResponseDto>
        {
            var result = await mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            return await HandleCommand(command);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            return await HandleCommand(command);

        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgetPassword([FromBody] SendOtpCommand command)
        {
            return await HandleCommand(command);

        }

        [HttpPost("verifyOtp")]
        public async Task<IActionResult> VerifyOtp(VerifyOtpCommand command)
        {
            return await HandleCommand(command);
        }
       // [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
        {
            return await HandleCommand(command);
        }
    }
}
