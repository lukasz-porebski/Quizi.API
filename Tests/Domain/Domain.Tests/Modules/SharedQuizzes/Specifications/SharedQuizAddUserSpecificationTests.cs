using Domain.Modules.SharedQuizzes.Data;
using Domain.Modules.SharedQuizzes.Specifications;
using FluentAssertions;
using LP.Common.Domain.ValueObjects;
using LP.Common.TestsCore;
using Xunit;

namespace Domain.Tests.Modules.SharedQuizzes.Specifications;

public class SharedQuizAddUserSpecificationTests : BaseTest
{
    private readonly SharedQuizAddUserSpecification _specification = new();

    [InlineData(true, false)]
    [InlineData(false, true)]
    [Theory]
    public void SharedQuizAddUser_Should_BeValid_When_UserIsNotAlreadyAdded(bool userAlreadyAdded, bool expectedResult)
    {
        var newUserId = AggregateId.Generate();
        var currentUsers = userAlreadyAdded
            ? new HashSet<AggregateId> { newUserId }
            : new HashSet<AggregateId>();

        var data = new SharedQuizAddUserSpecificationData(currentUsers, newUserId);

        var result = _specification.IsValid(data);

        result.Should().Be(expectedResult);
    }
}