using BrownDog.Domain.PetContext.Aggregates.DogAggregate;
using BrownDog.Domain.PetContext.Aggregates.DogAggregate.Enums;
using FluentResults;

namespace BrownDog.Domain.PetContext.Aggregates.PetOwnerAggregate;

public record PetOwner : IAggregateRoot
{
    public PetOwner(Guid id, Breed favouriteBreed)
    {
        Id = id;
        FavouriteBreed = favouriteBreed;
    }

    public Breed FavouriteBreed { get; }

    public Guid Id { get; }

    public Result Pet(Dog dog)
    {
        if (dog.Breed != FavouriteBreed)
        {
            return Result.Fail(new UserError("Cannot pet dog of non-favourite breed."));
        }

        dog.Pet(this);

        return Result.Ok();
    }
}