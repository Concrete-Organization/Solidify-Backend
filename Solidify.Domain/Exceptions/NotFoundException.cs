namespace Solidify.Domain.Exceptions
{
    public class NotFoundException(string entityName, object entityId)
        : Exception($"{entityName} with id: {entityId} does not exist.");
}
