using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Specifications;

internal class QuizDeclaredQuestionsCountSpecification : ISpecification<IQuizQuestionsCountSpecification>
{
    public string FailureMessageCode => QuizMessageCodes.QuizIncorrectDefinedQuestionsCountInRunningQuiz;

    public bool IsValid(IQuizQuestionsCountSpecification data) =>
        data.QuestionsCountInRunningQuiz <= data.QuestionsCount;
}