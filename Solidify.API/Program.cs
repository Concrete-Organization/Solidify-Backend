using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Solidify.API.Extensions;
using Solidify.Application.Extensions;
using Solidify.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPresentation();
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

app.ConfigureMiddlewares();

