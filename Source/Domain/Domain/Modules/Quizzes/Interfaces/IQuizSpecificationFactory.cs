using Common.Domain.Specification;
using Domain.Modules.Quizzes.Data.Specifications;

namespace Domain.Modules.Quizzes.Interfaces;

public interface IQuizSpecificationFactory
{
    SpecificationBuilderDirector QuizPersist(QuizPersistSpecificationData specificationData);
    SpecificationBuilderDirector AddUser(QuizAddUserSpecificationData specificationData);
    SpecificationBuilderDirector RemoveUser(QuizRemoveUserSpecificationData specificationData);
    SpecificationBuilderDirector AddNewQuestions(QuizAddNewQuestionsSpecificationData specificationData);
}