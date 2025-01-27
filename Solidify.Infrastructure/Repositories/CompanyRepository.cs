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
    public class CompanyRepository(SolidifyDbContext context) : ICompanyRepository
    {
        public async Task AddCompany(Company company)
        {
             context.Companies.Add(company);
            await context.SaveChangesAsync();
        }
    }
}
