namespace Solidify.Domain.Exceptions
{
    public class FavoriteAlreadyExistsException(string resourceType)
        : Exception($"You have already favorite this {resourceType}.");
}
