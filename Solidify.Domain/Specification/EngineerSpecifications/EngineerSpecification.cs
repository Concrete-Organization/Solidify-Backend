using Solidify.Domain.Entities;

namespace Solidify.Domain.Specification.EngineerSpecifications
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
