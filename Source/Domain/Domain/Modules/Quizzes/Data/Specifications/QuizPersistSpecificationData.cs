using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Specifications.Questions;
using Domain.Modules.Quizzes.Helpers;
using Domain.Modules.Quizzes.Interfaces;
using Domain.Shared.Interfaces;

namespace Domain.Modules.Quizzes.Data.Specifications;

public class QuizPersistSpecificationData : IOwnerSpecification, IQuizQuestionsCountSpecification
{
    public int QuestionsCount { get; }
    public int QuestionsCountInRunningQuiz { get; }
    public AggregateId OwnerId { get; }
    public AggregateId UserId { get; }
    public string? Description { get; }
    public TimeSpan Duration { get; }
    public IReadOnlyCollection<QuizClosedQuestionSpecificationData> ClosedQuestions { get; }
    public IReadOnlyCollection<QuizQuestionSpecificationData> Questions { get; }

    internal QuizPersistSpecificationData(
        int questionsCountInRunningQuiz,
        string? description,
        TimeSpan duration,
        IReadOnlyCollection<QuizOpenQuestionSpecificationData> openQuestions,
        IReadOnlyCollection<QuizSingleChoiceQuestionSpecificationData> singleChoiceQuestions,
        IReadOnlyCollection<QuizMultipleChoiceQuestionSpecificationData> multipleChoiceQuestions,
        AggregateId owner,
        AggregateId userDeclaredAsOwner)
    {
        QuestionsCountInRunningQuiz = questionsCountInRunningQuiz;
        OwnerId = owner;
        UserId = userDeclaredAsOwner;
        Description = description;
        Duration = duration;
        ClosedQuestions = QuizSpecificationHelper.GetClosedQuestions(singleChoiceQuestions, multipleChoiceQuestions);
        Questions = QuizSpecificationHelper.GetQuestions(openQuestions, singleChoiceQuestions, multipleChoiceQuestions);
        QuestionsCount = Questions.Count;
    }
}