using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.Accounts.Commands.Login;
using Solidify.Application.Accounts.Commands.RefreshToken;
using Solidify.Application.Accounts.Commands.Register;
using Solidify.Application.Accounts.Commands.ResetPassword;
using Solidify.Application.Accounts.Commands.RevokeToken;
using Solidify.Application.Accounts.Commands.SendOtp;
using Solidify.Application.Accounts.Commands.VerifyOtp;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Companies.Commands.Register;
using Solidify.Application.Enginners.Commands.Register;

namespace Solidify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController(IMediator mediator) : BaseController(mediator)
    {
        [HttpPost("registerEngineer")]
        public async Task<IActionResult> RegisterEngineer(RegisterEngineerCommand command)
        {
            return await HandleCommand(command);
        }

        [HttpPost("registerCompany")]
        public async Task<IActionResult> RegisterCompany([FromForm]RegisterCompanyCommand command)
        {
            return await HandleCommand(command);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            return await HandleCommand(command);

        }
        
        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
        {
            return await HandleCommand(command);
        }

        [HttpDelete("revokeToken")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenCommand command)
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
