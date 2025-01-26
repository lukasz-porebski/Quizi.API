using AutoFixture;
using Common.Domain.ValueObjects;

namespace Common.TestsCore;

public class BaseTest
{
    protected BaseTest()
    {
        Fixture = new Fixture();

        Fixture.Customize<AggregateId>(c => c.FromFactory(AggregateId.Generate));
        Fixture.Customize<EntityNo>(c => c.FromFactory(EntityNo.Generate));
        Fixture.Customize<AggregateStateChangeInfo>(c => c.FromFactory(() => new AggregateStateChangeInfo(null, DateTime.UtcNow)));
    }

    public IFixture Fixture { get; }
}