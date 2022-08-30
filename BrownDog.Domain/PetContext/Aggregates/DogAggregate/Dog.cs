using BrownDog.Domain.PetContext.Aggregates.DogAggregate.Enums;
using BrownDog.Domain.PetContext.Aggregates.PetOwnerAggregate;

namespace BrownDog.Domain.PetContext.Aggregates.DogAggregate;

public record Dog : IAggregateRoot
{
    public Dog(Guid id, Breed breed)
    {
        Id = id;
        Breed = breed;
    }

    public Breed Breed { get; }
    public Guid? LastPettedByOwnerId { get; private set; }

    public Guid Id { get; }

    internal void Pet(PetOwner owner)
    {
        LastPettedByOwnerId = owner.Id;
    }
}