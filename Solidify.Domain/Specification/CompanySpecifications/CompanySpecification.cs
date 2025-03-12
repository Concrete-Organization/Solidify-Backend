using Solidify.Domain.Entities.ECommerce.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Domain.Specification.CompanySpecification
{
    public class CompanySpecification : BaseSpecification<ConcreteCompany>
    {
        public CompanySpecification(string id) : base(c=>c.ConcreteCompanyId == id)
        {
            getInclude();
        }

        private void getInclude()
        {
            AddIncludes(c => c.User);
        }
    }
}
