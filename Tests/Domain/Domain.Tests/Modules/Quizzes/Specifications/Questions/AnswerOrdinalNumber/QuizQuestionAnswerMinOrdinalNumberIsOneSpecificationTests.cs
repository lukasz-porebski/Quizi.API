using AutoFixture;
using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.Specifications.Questions.AnswerOrdinalNumber;
using FluentAssertions;
using LP.Common.TestsCore;
using Xunit;

namespace Domain.Tests.Modules.Quizzes.Specifications.Questions.AnswerOrdinalNumber;

public class QuizQuestionAnswerMinOrdinalNumberIsOneSpecificationTests : BaseTest
{
    private readonly QuizQuestionAnswerMinOrdinalNumberIsOneSpecification _specification = new();

    [Fact]
    public void AnswerMinOrdinalNumberThatIsEqualToOne_Should_BeValid()
    {
        var answers = new List<QuizPersistClosedQuestionAnswerData>
        {
            Fixture.Create<QuizPersistClosedQuestionAnswerData>() with { OrdinalNumber = 1 },
            Fixture.Create<QuizPersistClosedQuestionAnswerData>() with { OrdinalNumber = 2 },
        };
        var data = Fixture.Create<QuizClosedQuestionCreateData>() with { Answers = answers };

        var result = _specification.IsValid(data);

        result.Should().BeTrue();
    }

    [Fact]
    public void AnswerMinOrdinalNumberThatIsNotEqualToOne_Should_BeInvalid()
    {
        var answers = new List<QuizPersistClosedQuestionAnswerData>
        {
            Fixture.Create<QuizPersistClosedQuestionAnswerData>() with { OrdinalNumber = 3 }
        };
        var data = Fixture.Create<QuizClosedQuestionCreateData>() with { Answers = answers };

        var result = _specification.IsValid(data);

        result.Should().BeFalse();
    }
}