using Solidify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Domain.Specification.EngineerSpecification
{
    public class EngineerSpecification : BaseSpecification<Engineer>
    {
        public EngineerSpecification(string id) : base(e => e.EngineerId == id)
        {
            GetIncludes();
        }

        private void GetIncludes()
        {
            AddIncludes(e => e.User);
        }
    }

}
