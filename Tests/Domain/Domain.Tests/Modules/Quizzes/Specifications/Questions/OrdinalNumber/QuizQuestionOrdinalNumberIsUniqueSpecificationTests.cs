using AutoFixture;
using Domain.Modules.Quizzes.Data.Specifications.Sub;
using Domain.Modules.Quizzes.Specifications.Questions.OrdinalNumber;
using FluentAssertions;
using LP.Common.TestsCore;
using Xunit;

namespace Domain.Tests.Modules.Quizzes.Specifications.Questions.OrdinalNumber;

public class QuizQuestionOrdinalNumberIsUniqueSpecificationTests : BaseTest
{
    private readonly QuizQuestionOrdinalNumberIsUniqueSpecification _specification = new();

    [Fact]
    public void QuestionOrdinalNumberThatIsUnique_Should_BeValid()
    {
        var questions = new List<QuizQuestionSpecificationData>
        {
            Fixture.Create<QuizQuestionSpecificationData>() with { OrdinalNumber = 1 },
            Fixture.Create<QuizQuestionSpecificationData>() with { OrdinalNumber = 2 }
        };

        var result = _specification.IsValid(questions);

        result.Should().BeTrue();
    }

    [Fact]
    public void QuestionOrdinalNumberThatIsNotUnique_Should_BeInvalid()
    {
        var question = Fixture.Create<QuizQuestionSpecificationData>();
        var questions = new List<QuizQuestionSpecificationData>
        {
            question,
            question
        };

        var result = _specification.IsValid(questions);

        result.Should().BeFalse();
    }
}