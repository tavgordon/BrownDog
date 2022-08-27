using BrownDog.Domain.PetContext.Aggregates.DogAggregate;
using BrownDog.Domain.PetContext.Aggregates.DogAggregate.Enums;

namespace BrownDog.Domain.PetContext.Aggregates.PetOwnerAggregate;

public record PetOwner : IAggregateRoot
{
    public PetOwner(Guid id, Breed favouriteBreed)
    {
        Id = id;
        FavouriteBreed = favouriteBreed;
    }

    public Guid Id { get; }
    public Breed FavouriteBreed { get; }
    
    public void Pet(Dog dog)
    {
        if (dog.Breed != FavouriteBreed)
        {
            throw new InvalidOperationException();
        }

        dog.Pet(this);
    }
}