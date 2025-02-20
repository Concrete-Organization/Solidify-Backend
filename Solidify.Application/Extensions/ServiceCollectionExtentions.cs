using System.Reflection;
using System.Text;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Solidify.Application.Common.User;
using Solidify.Application.E_Commerce.Products.Dtos;
using Solidify.Application.E_Commerce.Products.Resolvers;
using Solidify.Application.Email.Services;
using Solidify.Application.Email.Setting;
using Solidify.Application.Files;
using Solidify.Application.Jwt;
using Solidify.Application.Jwt.Services;
using Solidify.Application.Otp.Services;
using Solidify.Application.Services.Caching;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Interfaces.Services.Cashing;

namespace Solidify.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var appAssembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(appAssembly));


            services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
            services.AddScoped<IJwtService, JwtService>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),

                };
            });

            services.AddAutoMapper(appAssembly);
            services.AddSingleton<IValueResolver<Product, ProductDto, string>, ImageUriResolver>();

            services.AddValidatorsFromAssembly(appAssembly)
                .AddFluentValidationAutoValidation();

            services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));

            services.AddMemoryCache();
            services.AddDistributedMemoryCache();

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IOtpService, OtpService>();

            services.AddScoped<IFileService, FileService>();

            services.AddSingleton<ICacheService, CacheService>();

            services.AddScoped<ICurrentUser, CurrentUser>();
        }

    }
}
