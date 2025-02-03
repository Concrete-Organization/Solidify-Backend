using Solidify.Application.Common;

namespace Solidify.API.Middlewares
{
    public class UnauthorizedMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);

            if (context.Response.StatusCode == StatusCodes.Status404NotFound && !context.User.Identity.IsAuthenticated)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(
                    GeneralResponse.CreateResponse(false, StatusCodes.Status401Unauthorized, null, ""));
            }
        }
    }
}
