using Solidify.Domain.Entities;
using Solidify.Domain.Interfaces;
using Solidify.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Infrastructure.Repositories
{
    public class EngineerRepository(SolidifyDbContext context) : IEngineerRepository
    {
        public async Task AddEngineerAsync(Engineer engineer)
        {
           await context.Engineers.AddAsync(engineer);
           await context.SaveChangesAsync();
        }
    }
}
