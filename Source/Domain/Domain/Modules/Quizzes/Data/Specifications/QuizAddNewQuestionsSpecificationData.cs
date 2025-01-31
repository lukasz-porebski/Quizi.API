using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Specifications.Questions;
using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Data.Specifications;

public record QuizAddNewQuestionsSpecificationData : IQuizOwnerSpecification, IQuizQuestionsCountSpecification
{
    public int QuestionsCount { get; }
    public int QuestionsCountInRunningQuiz { get; }
    public QuizQuestionsForAddNewQuestionsSpecificationData Questions { get; }
    public AggregateId OwnerId { get; }
    public AggregateId UserId { get; }

    public QuizAddNewQuestionsSpecificationData(
        int declaredQuestionsCount,
        QuizQuestionsForAddNewQuestionsSpecificationData questions,
        AggregateId ownerId,
        AggregateId userId)
    {
        QuestionsCountInRunningQuiz = declaredQuestionsCount;
        OwnerId = ownerId;
        UserId = userId;
        Questions = questions;
        QuestionsCount = Questions.GetAllQuestionsCount();
    }
}