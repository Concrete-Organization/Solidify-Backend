using Solidify.Domain.Entities;

namespace Solidify.Application.Common.User;

public interface ICurrentUser
{
    string GetUserId();
    Task<Engineer?> GetEngineer(string engineerId);
}