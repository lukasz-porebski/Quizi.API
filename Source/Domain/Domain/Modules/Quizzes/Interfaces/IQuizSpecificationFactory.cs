using Common.Domain.Specification;
using Domain.Modules.Quizzes.Data.Specifications;

namespace Domain.Modules.Quizzes.Interfaces;

public interface IQuizSpecificationFactory
{
    SpecificationBuilderDirector QuizPersist(QuizPersistSpecificationData data);
    SpecificationBuilderDirector AddNewQuestions(QuizAddNewQuestionsSpecificationData data);
}