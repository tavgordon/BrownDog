namespace BrownDog.Domain.PetContext.Aggregates.PetOwnerAggregate;

public interface IPetOwnerRepository
{
    PetOwner Load(Guid id);
    void Save(PetOwner petOwner);
}