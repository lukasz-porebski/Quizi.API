using AutoFixture;
using Common.TestsCore;
using Domain.Modules.Quizzes.Data.Specifications.Sub;
using Domain.Modules.Quizzes.Specifications.Questions;
using FluentAssertions;
using Xunit;

namespace Domain.Tests.Modules.Quizzes.Specifications.Questions;

public class QuizHasAtLeastOneQuestionSpecificationTests : BaseTest
{
    private readonly QuizHasAtLeastOneQuestionSpecification _specification = new();

    [Fact]
    public void QuizThatHasAtLeastOneQuestion_Should_BeValid()
    {
        var data = Fixture.CreateMany<QuizQuestionSpecificationData>().ToArray();

        var result = _specification.IsValid(data);

        result.Should().BeTrue();
    }

    [Fact]
    public void QuizThatHasNotAnyQuestion_Should_BeInvalid()
    {
        var result = _specification.IsValid(Array.Empty<QuizQuestionSpecificationData>());

        result.Should().BeFalse();
    }
}