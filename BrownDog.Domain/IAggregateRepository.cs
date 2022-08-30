using FluentResults;

namespace BrownDog.Domain;

public interface IAggregateRepository<TAggregate> where TAggregate : IAggregateRoot
{
    Result<TAggregate> Load(Guid id);
    void Save(TAggregate aggregate);
}