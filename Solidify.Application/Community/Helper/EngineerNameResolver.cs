using AutoMapper;
using Solidify.Application.Common.User;
using Solidify.Application.Community.Posts.Dtos;
using Solidify.Domain.Entities.Community;

namespace Solidify.Application.Community.Helper
{
    public class EngineerNameResolver<Tsource, TDestination>(ICurrentUser currentUser) : IValueResolver<Tsource, TDestination, string?>
    where TDestination : EngineerInfo
    {
        public string? Resolve(Tsource source, TDestination destination, string? destMember, ResolutionContext context)
        {
            var engineer = currentUser.GetEngineer(destination.UserId).GetAwaiter().GetResult();
            if (engineer is not null)
            {
                if (engineer.EngineerName is not null)
                    destination.EngineerName = engineer.EngineerName;
            }

            return destination.EngineerName;
        }
    }
}
