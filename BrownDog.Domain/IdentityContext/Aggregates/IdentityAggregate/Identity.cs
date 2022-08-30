using BrownDog.Domain.IdentityContext.Aggregates.IdentityAggregate.Enums;

namespace BrownDog.Domain.IdentityContext.Aggregates.IdentityAggregate;

public record Identity : IAggregateRoot
{
    public Identity(Guid id, Role role)
    {
        Id = id;
        Role = role;
    }

    public Role Role { get; }

    public Guid Id { get; }
}