using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;

namespace Domain.Modules.Quizzes.Specifications.Questions;

internal class QuizQuestionAnswerTextSpecification : ISpecification<string>
{
    public string FailureMessageCode => QuizMessageCodes.AnswerIsEmpty;

    public bool IsValid(string data) =>
        data.Any();
}