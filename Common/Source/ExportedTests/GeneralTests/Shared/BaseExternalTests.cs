using Common.TestsCore;
using FluentAssertions;

namespace Common.GeneralTests.Shared;

public class BaseExternalTests : BaseTest
{
    protected void AssertInvalid(IEnumerable<Type> types, Func<Type, bool> predicate)
    {
        var invalidTypeNames = types.Where(predicate.Invoke).Select(t => t.Name).ToArray();

        invalidTypeNames.Should().BeEmpty();
    }

    protected void AssertDeclarationHasImplementation(
        IEnumerable<Type> declarationTypes, IEnumerable<Type> implementationTypes, Type genericType)
    {
        var implementationInterfaces = implementationTypes.SelectMany(i => i.GetInterfaces()).ToArray();
        var implementationsWithGivenGenericType = implementationInterfaces
            .Where(p => p.Name == genericType.Name && p.Namespace == genericType.Namespace)
            .ToArray();

        var invalidTypeNames = declarationTypes
            .Where(t => implementationsWithGivenGenericType.Any(i => i.GenericTypeArguments.Any(a => a.GetType() == t)))
            .Select(t => t.Name).ToArray();

        invalidTypeNames.Should().BeEmpty();
    }

    protected void AssertNumberOfDeclarationsAndImplementationsAreSame(
        IEnumerable<Type> declarationTypes, IEnumerable<Type> implementationTypes)
    {
        declarationTypes.Count().Should().Be(implementationTypes.Count());
    }
}