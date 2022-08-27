namespace BrownDog.Domain.IdentityContext.Aggregates.IdentityAggregate;

public interface IIdentityRepository
{
    Identity Load(Guid id);
    void Save(Identity identity);
}