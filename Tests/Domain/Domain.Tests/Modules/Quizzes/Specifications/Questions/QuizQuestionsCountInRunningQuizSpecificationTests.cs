using Common.TestsCore;
using Domain.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.Specifications;
using FluentAssertions;
using Xunit;

namespace Domain.Tests.Modules.Quizzes.Specifications.Questions;

public class QuizQuestionsCountInRunningQuizSpecificationTests : BaseTest
{
    private readonly QuizQuestionsCountInRunningQuizSpecification _specification = new();

    [InlineData(1, 1)]
    [InlineData(1, 2)]
    [Theory]
    public void QuestionsCountInRunningQuiz_Should_BeValid(int questionsCountInRunningQuiz, int questionsCount)
    {
        var result = _specification.IsValid(new TestObject(questionsCountInRunningQuiz, questionsCount));

        result.Should().BeTrue();
    }

    [InlineData(0, 1)]
    [InlineData(2, 1)]
    [Theory]
    public void QuestionsCountInRunningQuiz_Should_BeInvalid(int questionsCountInRunningQuiz, int questionsCount)
    {
        var result = _specification.IsValid(new TestObject(questionsCountInRunningQuiz, questionsCount));

        result.Should().BeFalse();
    }

    private sealed record TestObject(int QuestionsCountInRunningQuiz, int QuestionsCount) : IQuizQuestionsCountSpecification;
}