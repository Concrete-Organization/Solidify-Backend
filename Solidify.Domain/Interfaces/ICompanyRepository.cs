using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solidify.Domain.Entities.ECommerce.Companies;

namespace Solidify.Domain.Interfaces
{
    public interface ICompanyRepository
    {
        Task AddCompany(ConcreteCompany company);
    }
}
