using Domain.Modules.Quizzes.Data.Specifications;
using LP.Common.Domain.Specification;

namespace Domain.Modules.Quizzes.Interfaces;

public interface IQuizSpecificationFactory
{
    SpecificationBuilderDirector QuizPersist(QuizPersistSpecificationData data);
    SpecificationBuilderDirector AddNewQuestions(QuizAddNewQuestionsSpecificationData data);
}