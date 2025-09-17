using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Models.Sub;

namespace Domain.Modules.Quizzes.Specifications.Questions.AnswerOrdinalNumber;

internal class QuizQuestionAnswerMinOrdinalNumberIsOneSpecification : ISpecification<QuizClosedQuestionCreateData>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionAnswerMinOrdinalNumberHasToBeOne;

    public bool IsValid(QuizClosedQuestionCreateData data) =>
        data.Answers.Min(q => q.OrdinalNumber).Equals(1);
}