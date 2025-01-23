using Solidify.Domain.Entities;

namespace Solidify.Domain.Interfaces
{
    public interface IEngineerRepository
    {
        Task AddEngineerAsync(Engineer engineer);
    }
}
