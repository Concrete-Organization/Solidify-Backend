using MediatR;
using Microsoft.AspNetCore.Identity;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Jwt.Services;
using Solidify.Domain.Entities;

namespace Solidify.Application.Accounts.Commands.Register;

public class RegisterUserCommandHandler(UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager) : IRequestHandler<RegisterUserCommand, GeneralResponseDto>
{
    public async Task<GeneralResponseDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            UserName = request.UserName,
            Email = request.Email,

        };

        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            return new GeneralResponseDto
            {
                IsSucceeded = false,
                Message = "Registration failed",
                Model = result.Errors.Select(e => e.Description).ToList(),
                StatusCode = 400
            };
        }


        await userManager.AddToRoleAsync(user, "User");
        await signInManager.SignInAsync(user, isPersistent: false);


        return new GeneralResponseDto
        {
            IsSucceeded = true,
            Message = "User registered successfully",
            Model = new { user.Id, user.UserName, user.Email },
            StatusCode = 201
        };
    }
}
