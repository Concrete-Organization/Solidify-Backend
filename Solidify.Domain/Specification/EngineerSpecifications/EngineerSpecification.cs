using Solidify.Domain.Entities;

namespace Solidify.Domain.Specification.EngineerSpecifications
{
    public class EngineerSpecification : BaseSpecification<Engineer>
    {
        public EngineerSpecification(string engineerId) : base(e => e.EngineerId == engineerId)
        {
            
        }
    }
}
