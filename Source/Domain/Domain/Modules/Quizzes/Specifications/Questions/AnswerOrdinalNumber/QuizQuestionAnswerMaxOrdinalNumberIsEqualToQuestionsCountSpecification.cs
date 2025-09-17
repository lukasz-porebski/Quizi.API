using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Models.Sub;

namespace Domain.Modules.Quizzes.Specifications.Questions.AnswerOrdinalNumber;

internal class QuizQuestionAnswerMaxOrdinalNumberIsEqualToQuestionsCountSpecification
    : ISpecification<QuizClosedQuestionCreateData>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionAnswerMaxOrdinalNumberHasToBeQuestionsCount;

    public bool IsValid(QuizClosedQuestionCreateData data) =>
        data.Answers.Max(q => q.OrdinalNumber).Equals(data.Answers.Count);
}