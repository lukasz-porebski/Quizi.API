using AutoFixture;
using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.Specifications.Questions;
using FluentAssertions;
using LP.Common.TestsCore;
using Xunit;

namespace Domain.Tests.Modules.Quizzes.Specifications.Questions;

public class QuizQuestionAnswersAreUniqueSpecificationTests : BaseTest
{
    private readonly QuizQuestionAnswersAreUniqueSpecification _specification = new();

    [Fact]
    public void QuestionNotContainingDuplicateAnswer_Should_BeValid()
    {
        var data = Fixture.Create<QuizClosedQuestionCreateData>() with
        {
            Answers =
            [
                Fixture.Create<QuizPersistClosedQuestionAnswerData>(),
                Fixture.Create<QuizPersistClosedQuestionAnswerData>()
            ]
        };

        var result = _specification.IsValid(data);

        result.Should().BeTrue();
    }

    [Fact]
    public void QuestionContainingDuplicateAnswer_Should_BeInvalid()
    {
        var answer = Fixture.Create<QuizPersistClosedQuestionAnswerData>();
        var data = Fixture.Create<QuizClosedQuestionCreateData>() with
        {
            Answers =
            [
                answer,
                answer
            ]
        };

        var result = _specification.IsValid(data);

        result.Should().BeFalse();
    }
}