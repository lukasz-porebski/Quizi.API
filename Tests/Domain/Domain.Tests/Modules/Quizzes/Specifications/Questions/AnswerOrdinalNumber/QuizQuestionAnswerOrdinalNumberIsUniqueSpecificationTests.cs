using AutoFixture;
using Common.TestsCore;
using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.Specifications.Questions.AnswerOrdinalNumber;
using FluentAssertions;
using Xunit;

namespace Domain.Tests.Modules.Quizzes.Specifications.Questions.AnswerOrdinalNumber;

public class QuizQuestionAnswerOrdinalNumberIsUniqueSpecificationTests : BaseTest
{
    private readonly QuizQuestionAnswerOrdinalNumberIsUniqueSpecification _specification = new();

    [Fact]
    public void AnswerOrdinalNumberThatIsUnique_Should_BeValid()
    {
        var answers = new List<QuizPersistClosedQuestionAnswerData>
        {
            Fixture.Create<QuizPersistClosedQuestionAnswerData>() with { OrdinalNumber = 1 },
            Fixture.Create<QuizPersistClosedQuestionAnswerData>() with { OrdinalNumber = 2 },
            Fixture.Create<QuizPersistClosedQuestionAnswerData>() with { OrdinalNumber = 3 }
        };
        var data = Fixture.Create<QuizClosedQuestionCreateData>() with { Answers = answers };

        var result = _specification.IsValid(data);

        result.Should().BeTrue();
    }

    [Fact]
    public void AnswerOrdinalNumberThatIsNotUnique_Should_BeInvalid()
    {
        var answer = Fixture.Create<QuizPersistClosedQuestionAnswerData>();
        var answers = new List<QuizPersistClosedQuestionAnswerData>
        {
            answer,
            answer
        };
        var data = Fixture.Create<QuizClosedQuestionCreateData>() with { Answers = answers };

        var result = _specification.IsValid(data);

        result.Should().BeFalse();
    }
}