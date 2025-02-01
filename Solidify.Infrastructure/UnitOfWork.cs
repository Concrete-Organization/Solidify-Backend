using System.Collections;
using Solidify.Domain.Interfaces;
using Solidify.Infrastructure.Persistance;
using Solidify.Infrastructure.Repositories;

namespace Solidify.Infrastructure;

public class UnitOfWork(SolidifyDbContext context) 
    : IUnitOfWork
{
    private readonly Hashtable _repositories = new();
    public async Task<int> Commit()
    {
        return await context.SaveChangesAsync();
    }

    public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        var type = typeof(TEntity).Name;

        if (!_repositories.Contains(type))
        {
            var repo = new GenericRepository<TEntity>(context);
            _repositories.Add(type, repo);
        }

        return _repositories[type] as IGenericRepository<TEntity>;
    }
}