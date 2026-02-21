using AutoFixture;
using Common.TestsCore;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Specifications.Questions;
using FluentAssertions;
using Xunit;

namespace Domain.Tests.Modules.Quizzes.Specifications.Questions
{
    public class QuizQuestionTextSpecificationTests : BaseTest
    {
        private readonly QuizQuestionTextSpecification _specification = new();

        [Fact]
        public void QuestionThatHasText_Should_BeValid()
        {
            var result = _specification.IsValid(Fixture.Create<string>());

            result.Should().BeTrue();
        }

        [Fact]
        public void QuestionThatHasNotText_Should_BeInvalid()
        {
            var result = _specification.IsValid(string.Empty);

            result.Should().BeFalse();
        }

        [Fact]
        public void QuestionThatIsLongerThanMaxLength_Should_BeInvalid()
        {
            var text = string.Join("", Enumerable.Range(0, QuizConstants.MaxQuestionTextLength));

            var result = _specification.IsValid(text);

            result.Should().BeFalse();
        }
    }
}