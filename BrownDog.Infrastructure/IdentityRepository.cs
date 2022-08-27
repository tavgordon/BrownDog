using BrownDog.Domain.IdentityContext.Aggregates.IdentityAggregate;

namespace BrownDog.Infrastructure;

public class IdentityRepository : IIdentityRepository
{
    private readonly Dictionary<Guid, Identity> _identities = new();

    public Identity Load(Guid id)
    {
        return _identities[id];
    }

    public void Save(Identity identity)
    {
        _identities[identity.Id] = identity;
    }
}