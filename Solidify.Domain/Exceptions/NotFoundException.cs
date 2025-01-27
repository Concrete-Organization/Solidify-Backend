namespace Solidify.Domain.Exceptions
{
    public class NotFoundException(string entityName, string entityId)
        : Exception($"{entityName} with id: {entityId} does not exist.");
}
