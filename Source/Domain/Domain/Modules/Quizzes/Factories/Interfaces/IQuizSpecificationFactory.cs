using Common.Domain.Specification;
using Domain.Modules.Quizzes.Specifications.Data;

namespace Domain.Modules.Quizzes.Factories.Interfaces;

public interface IQuizSpecificationFactory
{
    SpecificationBuilderDirector QuizPersist(QuizPersistSpecificationData specificationData);
    SpecificationBuilderDirector AddUser(QuizAddUserSpecificationData specificationData);
    SpecificationBuilderDirector RemoveUser(QuizRemoveUserSpecificationData specificationData);
    SpecificationBuilderDirector AddNewQuestions(QuizAddNewQuestionsSpecificationData specificationData);
}