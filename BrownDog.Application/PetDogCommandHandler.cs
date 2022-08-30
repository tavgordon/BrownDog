using BrownDog.Domain;
using BrownDog.Domain.PetContext.Aggregates.DogAggregate;
using BrownDog.Domain.PetContext.Aggregates.PetOwnerAggregate;
using BrownDog.Domain.PetContext.Services;
using FluentResults;

namespace BrownDog.Application;

public class PetDogCommandHandler
{
    private readonly IAggregateRepository<Dog> _dogRepository;
    private readonly IAggregateRepository<PetOwner> _petOwnerRepository;
    private readonly IPettingService _pettingService;

    public PetDogCommandHandler(
        IAggregateRepository<PetOwner> petOwnerRepository,
        IAggregateRepository<Dog> dogRepository,
        IPettingService pettingService)
    {
        _petOwnerRepository = petOwnerRepository;
        _dogRepository = dogRepository;
        _pettingService = pettingService;
    }

    public Result Handle(PetDogCommand command)
    {
        var dogResult = _dogRepository.Load(command.DogId);

        if (dogResult.IsFailed)
        {
            return dogResult.ToResult();
        }

        return _pettingService.PetDog(command.IdentityId, dogResult.Value);
    }
}