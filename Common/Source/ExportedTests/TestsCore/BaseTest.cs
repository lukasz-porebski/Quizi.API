using AutoFixture;
using AutoFixture.Kernel;
using Common.Domain.ValueObjects;

namespace Common.TestsCore;

public abstract class BaseTest
{
    protected BaseTest()
    {
        Fixture = new Fixture();

        Fixture.Customize<AggregateId>(c => c.FromFactory(AggregateId.Generate));
        Fixture.Customize<EntityNo>(c => c.FromFactory(EntityNo.Generate));
        Fixture.Customize<AggregateStateChangeInfo>(c =>
            c.FromFactory(() => new AggregateStateChangeInfo(null, DateTime.UtcNow)));
        Fixture.Customizations.Add(new TypeRelay(typeof(IReadOnlySet<AggregateId>), typeof(HashSet<AggregateId>)));
    }

    public IFixture Fixture { get; }

    protected string FixtureString(int length) =>
        new(Fixture.CreateMany<char>(length).ToArray());
}