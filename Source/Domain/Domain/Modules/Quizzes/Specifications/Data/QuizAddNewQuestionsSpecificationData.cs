using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Specifications.Data.Questions;
using Domain.Modules.Quizzes.Specifications.Interfaces;

namespace Domain.Modules.Quizzes.Specifications.Data;

public class QuizAddNewQuestionsSpecificationData : IQuizOwnerSpecification, IQuizQuestionsCountSpecification
{
    public int QuestionsCount { get; }
    public int QuestionsCountInRunningQuiz { get; }
    internal QuizQuestionsForAddNewQuestionsSpecificationData Questions { get; }
    public AggregateId OwnerId { get; }
    public AggregateId UserId { get; }

    internal QuizAddNewQuestionsSpecificationData(
        int declaredQuestionsCount, QuizQuestionsForAddNewQuestionsSpecificationData questions,
        AggregateId ownerId, AggregateId userId)
    {
        QuestionsCountInRunningQuiz = declaredQuestionsCount;
        OwnerId = ownerId;
        UserId = userId;
        Questions = questions;
        QuestionsCount = Questions.GetAllQuestionsCount();
    }
}