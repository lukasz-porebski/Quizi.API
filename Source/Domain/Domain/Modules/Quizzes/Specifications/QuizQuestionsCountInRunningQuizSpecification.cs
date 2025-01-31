using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications;

namespace Domain.Modules.Quizzes.Specifications;

internal class QuizQuestionsCountInRunningQuizSpecification : ISpecification<QuizPersistSpecificationData>
{
    public string FailureMessageCode => QuizMessageCodes.QuizIncorrectDefinedQuestionsCountInRunningQuiz;

    public bool IsValid(QuizPersistSpecificationData data) =>
        data.QuestionsCountInRunningQuiz >= 1 && data.QuestionsCountInRunningQuiz <= data.QuestionsCount;
}