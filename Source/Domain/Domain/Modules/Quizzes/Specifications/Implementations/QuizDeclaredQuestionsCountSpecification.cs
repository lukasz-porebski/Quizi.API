using Common.Domain.Specification;
using Domain.Modules.Quizzes.Specifications.Interfaces;

namespace Domain.Modules.Quizzes.Specifications.Implementations;

internal class QuizDeclaredQuestionsCountSpecification : ISpecification<IQuizQuestionsCountSpecification>
{
    public string FailureMessageCode => QuizMessages.QuizIncorrectDefinedQuestionsCountInRunningQuiz();

    public bool IsValid(IQuizQuestionsCountSpecification data) =>
        data.QuestionsCountInRunningQuiz <= data.QuestionsCount;
}