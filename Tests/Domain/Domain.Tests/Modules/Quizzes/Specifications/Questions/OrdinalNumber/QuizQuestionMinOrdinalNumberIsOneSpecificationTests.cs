using AutoFixture;
using Common.TestsCore;
using Domain.Modules.Quizzes.Data.Specifications.Sub;
using Domain.Modules.Quizzes.Specifications.Questions.OrdinalNumber;
using FluentAssertions;
using Xunit;

namespace Domain.Tests.Modules.Quizzes.Specifications.Questions.OrdinalNumber;

public class QuizQuestionMinOrdinalNumberIsOneSpecificationTests : BaseTest
{
    private readonly QuizQuestionMinOrdinalNumberIsOneSpecification _specification = new();

    [Fact]
    public void QuestionMinOrdinalNumberThatIsEqualToOne_Should_BeValid()
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
    public void QuestionMinOrdinalNumberThatIsNotEqualToOne_Should_BeInvalid()
    {
        var questions = new List<QuizQuestionSpecificationData>
        {
            Fixture.Create<QuizQuestionSpecificationData>() with { OrdinalNumber = 2 },
            Fixture.Create<QuizQuestionSpecificationData>() with { OrdinalNumber = 3 }
        };

        var result = _specification.IsValid(questions);

        result.Should().BeFalse();
    }
}