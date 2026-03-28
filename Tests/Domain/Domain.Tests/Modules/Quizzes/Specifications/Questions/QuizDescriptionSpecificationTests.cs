using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Specifications;
using FluentAssertions;
using LP.Common.TestsCore;
using Xunit;

namespace Domain.Tests.Modules.Quizzes.Specifications.Questions;

public class QuizDescriptionSpecificationTests : BaseTest
{
    private readonly QuizDescriptionSpecification _specification = new();

    [InlineData(0)]
    [InlineData(QuizConstants.MaxDescriptionLength)]
    [Theory]
    public void DescriptionLengthInRange_Should_BeValid(int descriptionLength)
    {
        var result = _specification.IsValid(FixtureString(descriptionLength));

        result.Should().BeTrue();
    }

    [Fact]
    public void TooLongDescription_Should_BeInvalid()
    {
        var result = _specification.IsValid(FixtureString(QuizConstants.MaxDescriptionLength + 1));

        result.Should().BeFalse();
    }
}