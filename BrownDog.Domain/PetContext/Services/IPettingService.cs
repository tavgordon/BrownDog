using BrownDog.Domain.PetContext.Aggregates.DogAggregate;
using FluentResults;

namespace BrownDog.Domain.PetContext.Services;

public interface IPettingService
{
    Result PetDog(Guid ownerId, Dog dog);
}