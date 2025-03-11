using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Solidify.Domain.Entities;
using Solidify.Domain.Interfaces;

namespace Solidify.Application.Common.User
{
    public  class CurrentUser(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork) : ICurrentUser
    {
        public  string GetUserId()
        {
            return httpContextAccessor.HttpContext!.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        }
    }
}
