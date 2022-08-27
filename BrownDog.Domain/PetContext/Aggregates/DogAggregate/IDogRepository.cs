namespace BrownDog.Domain.PetContext.Aggregates.DogAggregate;

public interface IDogRepository
{
    Dog Load(Guid id);
    void Save(Dog dog);
}