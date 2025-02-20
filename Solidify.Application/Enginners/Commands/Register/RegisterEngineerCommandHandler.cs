using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Files;
using Solidify.Application.Jwt.Services;
using Solidify.Domain.Entities;
using Solidify.Domain.Interfaces;
using System;
using System.Collections.Generic;
using static Solidify.Application.Common.GeneralResponse;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Solidify.Domain.Enums;

namespace Solidify.Application.Enginners.Commands.Register
{
    public class RegisterEngineerCommandHandler(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager
        , IEngineerRepository engineerRepository) : IRequestHandler<RegisterEngineerCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(RegisterEngineerCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email
            };
            
            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return CreateResponse(false, 400, result.Errors.Select(e => e.Description).ToList(), "Registration failed");
              
            }

          
            var engineer = new Engineer
            {
                EngineerId = user.Id
            };

            //we must save changes to engineer table ????????????
            await engineerRepository.AddEngineerAsync(engineer);

            await userManager.AddToRoleAsync(user, "Engineer");
            await signInManager.SignInAsync(user, isPersistent: false);


            return CreateResponse(true, 201, new { user.Id, user.UserName, user.Email }, "Engineer registered successfully");
            
        }
    }
}
