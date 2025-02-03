using Solidify.API.Middlewares;

namespace Solidify.API.Extensions;

public static class WebApplicationExtension
{
    public static void ConfigureMiddlewares(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
        app.UseSwagger();
        app.UseSwaggerUI();
        //}

        app.UseMiddleware<ErrorHandlingMiddleware>();
        app.UseMiddleware<UnauthorizedMiddleware>();

        app.UseStaticFiles();
        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}