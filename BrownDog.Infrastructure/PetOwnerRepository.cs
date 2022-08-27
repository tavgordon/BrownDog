using BrownDog.Domain.IdentityContext.Aggregates.IdentityAggregate;
using BrownDog.Domain.IdentityContext.Aggregates.IdentityAggregate.Enums;
using BrownDog.Domain.PetContext.Aggregates.DogAggregate.Enums;
using BrownDog.Domain.PetContext.Aggregates.PetOwnerAggregate;

namespace BrownDog.Infrastructure;

public class PetOwnerRepository : IPetOwnerRepository
{
    private readonly Dictionary<Guid, Breed> _favouriteBreeds = new();
    private readonly IIdentityRepository _identityRepository;

    public PetOwnerRepository(IIdentityRepository identityRepository)
    {
        _identityRepository = identityRepository;
    }

    public PetOwner Load(Guid id)
    {
        var identity = _identityRepository.Load(id);

        if (identity.Role != Role.PetOwner)
        {
            throw new UnauthorizedAccessException(); // this feels like domain logic inside the infrastructure layer
        }

        return new PetOwner(id, _favouriteBreeds[id]);
    }

    public void Save(PetOwner petOwner)
    {
        _favouriteBreeds[petOwner.Id] = petOwner.FavouriteBreed;
    }
}