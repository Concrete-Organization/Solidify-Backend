using MediatR;
using Microsoft.AspNetCore.Identity;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Jwt.Services;
using Solidify.Domain.Entities;

namespace Solidify.Application.Accounts.Commands.Login;

public class LoginCommandHandler(UserManager<ApplicationUser> userManager
    ,SignInManager<ApplicationUser> signInManager, IJwtService jwtService
    ) : IRequestHandler<LoginCommand, GeneralResponseDto>
{
    public async Task<GeneralResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            return new GeneralResponseDto
            {
                IsSucceeded = false,
                StatusCode = 401,
                Message = "Email or Password is invalid"
            };
        }

        var result = await signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);
        if (!result.Succeeded)
        {
            return new GeneralResponseDto
            {
                IsSucceeded = false,
                StatusCode = 401,
                Message = "Email or Password is invalid"
            };
        }

        var authResponse = await jwtService.GenerateToken(user);

        return new GeneralResponseDto
        {
            IsSucceeded = true,
            Message = "Login successful",
            Model = authResponse,
            StatusCode = 200
        };
    }
}
