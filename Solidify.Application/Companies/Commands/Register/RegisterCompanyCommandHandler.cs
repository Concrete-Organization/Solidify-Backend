using MediatR;
using Microsoft.AspNetCore.Identity;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Files;
using Solidify.Domain.Entities;
using Solidify.Domain.Entities.ECommerce.Companies;
using Solidify.Domain.Enums;
using Solidify.Domain.Interfaces;
using static Solidify.Application.Common.GeneralResponse;

namespace Solidify.Application.Companies.Commands.Register
{
    public class RegisterCompanyCommandHandler(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager
        , IFileService fileService
        ,ICompanyRepository companyRepository
        ) : IRequestHandler<RegisterCompanyCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(RegisterCompanyCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
                Address = request.CompanyAddress,
            };
            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return CreateResponse(false, 400, result.Errors.Select(e => e.Description).ToList(), "Registration failed");
            }

            var licenseUploadResult = await fileService.UploadFileAsync(request.CommericalLicense, FileType.License);
            if (!licenseUploadResult.IsSucceeded)
            {
                await userManager.DeleteAsync(user);
                return licenseUploadResult;
            }

            var company = new Company
            {   
                CompanyId = user.Id,
                CompanyName = request.CompanyName,
                CommericalLicense = licenseUploadResult.Model.ToString(),
                CommericalNumber = request.CommericalNumber,
                TaxId = request.TaxId,
            };

            await companyRepository.AddCompany(company);

            await userManager.AddToRoleAsync(user, "Company");
            await signInManager.SignInAsync(user, isPersistent: false);
            return CreateResponse(true, 201, new {user.Id, user.UserName, company.CompanyName, user.Email }, "Company registered successfully");

        }
    }
}
