using BrownDog.Domain.PetContext.Aggregates.DogAggregate;

namespace BrownDog.Infrastructure;

public class DogRepository : IDogRepository
{
    private readonly Dictionary<Guid, Dog> _dogs = new();

    public Dog Load(Guid id)
    {
        return _dogs[id];
    }

    public void Save(Dog dog)
    {
        _dogs[dog.Id] = dog;
    }
}