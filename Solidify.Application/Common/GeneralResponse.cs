using Solidify.Application.Common.Dtos;

namespace Solidify.Application.Common
{
    public static class GeneralResponse
    {
        public static GeneralResponseDto CreateResponse(bool success, int statusCode, Object? Model, string? message)
        {
            return new GeneralResponseDto
            {
                IsSucceeded = success,
                StatusCode = statusCode,
                Message = message,
                Model = Model,
            };
        }
    }
}
