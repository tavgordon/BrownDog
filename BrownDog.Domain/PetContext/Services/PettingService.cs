using BrownDog.Domain.IdentityContext.Aggregates.IdentityAggregate;
using BrownDog.Domain.IdentityContext.Aggregates.IdentityAggregate.Enums;
using BrownDog.Domain.PetContext.Aggregates.DogAggregate;
using BrownDog.Domain.PetContext.Aggregates.PetOwnerAggregate;
using FluentResults;

namespace BrownDog.Domain.PetContext.Services;

public class PettingService : IPettingService
{
    private readonly IAggregateRepository<Dog> _dogRepository;
    private readonly IAggregateRepository<Identity> _identityRepository;
    private readonly IAggregateRepository<PetOwner> _petOwnerRepository;

    public PettingService(
        IAggregateRepository<Identity> identityRepository,
        IAggregateRepository<PetOwner> petOwnerRepository,
        IAggregateRepository<Dog> dogRepository)
    {
        _identityRepository = identityRepository;
        _petOwnerRepository = petOwnerRepository;
        _dogRepository = dogRepository;
    }

    public Result PetDog(Guid ownerId, Dog dog)
    {
        /*
         * What we want is to return a NotFoundError result if the identity doesn't exist at all...
         * Or to return a ForbiddenError if the identity is found but is not of role PetOwner.
         *
         * What I don't like here is that we are accessing Identity which is in a different Bounded Context.
         * How do we do this properly?
         */
        var identityResult = _identityRepository.Load(ownerId);

        if (identityResult.IsFailed)
        {
            return identityResult.ToResult();
        }

        var identity = identityResult.Value;

        if (identity.Role != Role.PetOwner)
        {
            return Result.Fail(new ForbiddenError());
        }

        var petOwnerResult = _petOwnerRepository.Load(ownerId);

        if (petOwnerResult.IsFailed)
        {
            return petOwnerResult.ToResult();
        }

        var owner = petOwnerResult.Value;

        var petResult = owner.Pet(dog);

        if (petResult.IsFailed)
        {
            return petResult;
        }

        _dogRepository.Save(dog);

        return Result.Ok();
    }
}