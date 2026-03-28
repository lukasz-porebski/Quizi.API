using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Models.Sub;
using LP.Common.Domain.Specification;

namespace Domain.Modules.Quizzes.Specifications.Questions;

internal class QuizMultipleChoiceQuestionHasAtLeastOneCorrectAnswerSpecification
    : ISpecification<QuizClosedQuestionCreateData>
{
    public string FailureMessageCode => QuizMessageCodes.QuizMultipleChoiceQuestionHasAtLeastOneCorrectAnswer;

    public bool IsValid(QuizClosedQuestionCreateData data) =>
        data.Answers.Any(a => a.IsCorrect);
}