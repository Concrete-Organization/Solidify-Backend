using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Solidify.Application.Common.User
{
    public  class CurrentUser(IHttpContextAccessor httpContextAccessor) : ICurrentUser
    {
        public  string GetUserId()
        {
            return httpContextAccessor.HttpContext!.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        }
    }
}
