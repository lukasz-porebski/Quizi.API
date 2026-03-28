using AutoFixture;
using Domain.Modules.Quizzes.Data.Specifications.Sub;
using Domain.Modules.Quizzes.Specifications.Questions;
using FluentAssertions;
using LP.Common.TestsCore;
using Xunit;

namespace Domain.Tests.Modules.Quizzes.Specifications.Questions;

public class QuizQuestionsAreUniqueSpecificationTests : BaseTest
{
    private readonly QuizQuestionsAreUniqueSpecification _specification = new();

    [Fact]
    public void UniqueQuestions_Should_BeValid()
    {
        var data = Fixture.CreateMany<QuizQuestionSpecificationData>().ToArray();

        var result = _specification.IsValid(data);

        result.Should().BeTrue();
    }

    [Fact]
    public void NonUniqueQuestions_Should_BeInvalid()
    {
        var question = Fixture.Create<QuizQuestionSpecificationData>();
        var data = new List<QuizQuestionSpecificationData>
        {
            question,
            Fixture.Create<QuizQuestionSpecificationData>(),
            question
        };

        var result = _specification.IsValid(data);

        result.Should().BeFalse();
    }
}