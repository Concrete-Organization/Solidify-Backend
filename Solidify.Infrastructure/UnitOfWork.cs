using System.Collections;
using Solidify.Domain.Interfaces;
using Solidify.Infrastructure.Persistance;
using Solidify.Infrastructure.Repositories;

namespace Solidify.Infrastructure;

public class UnitOfWork<TEntity>(SolidifyDbContext context) 
    : IUnitOfWork<TEntity> where TEntity : class
{
    private readonly Hashtable _repositories = new();
    public async Task<int> Commit()
    {
        return await context.SaveChangesAsync();
    }

    public IGenericRepository<TEntity> GetRepository()
    {
        var type = nameof(TEntity);

        if (!_repositories.Contains(type))
        {
            var repo = new GenericRepository<TEntity>(context);
            _repositories.Add(type, repo);
        }

        return _repositories[type] as IGenericRepository<TEntity>;
    }
}