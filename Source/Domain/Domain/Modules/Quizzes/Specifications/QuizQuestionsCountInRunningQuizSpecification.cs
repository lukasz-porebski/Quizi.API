using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Specifications;

internal class QuizQuestionsCountInRunningQuizSpecification : ISpecification<IQuizQuestionsCountSpecification>
{
    public string FailureMessageCode => QuizMessageCodes.QuizQuestionsCountInRunningQuizIsOutOfRange;

    public bool IsValid(IQuizQuestionsCountSpecification data) =>
        data.QuestionsCountInRunningQuiz >= 1 && data.QuestionsCountInRunningQuiz <= data.QuestionsCount;
}