using BrownDog.Domain;
using FluentResults;

namespace BrownDog.Infrastructure;

public class AggregateRepository<TAggregate> : IAggregateRepository<TAggregate> where TAggregate : IAggregateRoot
{
    private readonly Dictionary<Guid, TAggregate> _aggregates = new();

    public Result<TAggregate> Load(Guid id)
    {
        if (_aggregates.ContainsKey(id))
        {
            return _aggregates[id];
        }

        return Result.Fail(new NotFoundError());
    }

    public void Save(TAggregate aggregate)
    {
        _aggregates[aggregate.Id] = aggregate;
    }
}