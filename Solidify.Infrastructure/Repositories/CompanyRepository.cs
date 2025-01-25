using Solidify.Domain.Interfaces;
using Solidify.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solidify.Domain.Entities.ECommerce.Companies;

namespace Solidify.Infrastructure.Repositories
{
    public class CompanyRepository(SolidifyDbContext context) : ICompanyRepository
    {
        public async Task AddCompany(Company company)
        {
            await context.Companies.AddAsync(company);
            await context.SaveChangesAsync();
        }
    }
}
