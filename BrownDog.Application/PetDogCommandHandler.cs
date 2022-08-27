using BrownDog.Domain.PetContext.Aggregates.DogAggregate;
using BrownDog.Domain.PetContext.Aggregates.PetOwnerAggregate;

namespace BrownDog.Application;

public class PetDogCommandHandler
{
    private readonly IDogRepository _dogRepository;
    private readonly IPetOwnerRepository _petOwnerRepository;

    public PetDogCommandHandler(IPetOwnerRepository petOwnerRepository, IDogRepository dogRepository)
    {
        _petOwnerRepository = petOwnerRepository;
        _dogRepository = dogRepository;
    }

    public void Handle(PetDogCommand command)
    {
        var dog = _dogRepository.Load(command.DogId);
        var petOwner = _petOwnerRepository.Load(command.IdentityId);

        petOwner.Pet(dog);

        _dogRepository.Save(dog);
    }
}