using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Models.Sub;
using LP.Common.Domain.Specification;

namespace Domain.Modules.Quizzes.Specifications.Questions;

internal class QuizSingleChoiceQuestionHasExactlyOneCorrectAnswerSpecification
    : ISpecification<QuizClosedQuestionCreateData>
{
    public string FailureMessageCode => QuizMessageCodes.QuizSingleChoiceQuestionHasExactlyOneCorrectAnswer;

    public bool IsValid(QuizClosedQuestionCreateData data) =>
        data.Answers.Count(a => a.IsCorrect) == 1;
}