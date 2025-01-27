using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Domain.Exceptions;

namespace Solidify.API.Middlewares;

public class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            next.Invoke(context);
        }
        catch (NotFoundException notFound)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(GeneralResponse.CreateResponse(false, StatusCodes.Status404NotFound,
                null, notFound.Message));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}