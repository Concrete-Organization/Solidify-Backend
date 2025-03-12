using Microsoft.AspNetCore.Http.HttpResults;
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
            await next.Invoke(context);
        }
        catch (NotFoundException notFound)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(GeneralResponse.CreateResponse(false, StatusCodes.Status404NotFound,
                null, notFound.Message));
        }
        catch (BadRequestException e)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(GeneralResponse.CreateResponse(false, StatusCodes.Status400BadRequest,
                null, e.Message));
        }
        catch (FavoriteAlreadyExistsException alreadyExistsException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(GeneralResponse.CreateResponse(false,
                StatusCodes.Status400BadRequest,
                null, alreadyExistsException.Message));
        }
        catch (Exception e)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(GeneralResponse.CreateResponse(false, StatusCodes.Status500InternalServerError,
                null, "Something went wrong"));
        }
    }
}