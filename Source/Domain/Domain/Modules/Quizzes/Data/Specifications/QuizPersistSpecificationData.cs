using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.Data.Specifications.Sub;
using Domain.Modules.Quizzes.Helpers;
using Domain.Modules.Quizzes.Interfaces;
using Domain.Shared.Interfaces;

namespace Domain.Modules.Quizzes.Data.Specifications;

public class QuizPersistSpecificationData : IOwnerSpecification, IQuizQuestionsCountSpecification
{
    internal QuizPersistSpecificationData(
        int questionsCountInRunningQuiz,
        string title,
        string? description,
        TimeSpan duration,
        IReadOnlyCollection<QuizOpenQuestionPersistData> openQuestions,
        IReadOnlyCollection<QuizClosedQuestionCreateData> singleChoiceQuestions,
        IReadOnlyCollection<QuizClosedQuestionCreateData> multipleChoiceQuestions,
        AggregateId owner,
        AggregateId userDeclaredAsOwner)
    {
        QuestionsCountInRunningQuiz = questionsCountInRunningQuiz;
        OwnerId = owner;
        UserId = userDeclaredAsOwner;
        Title = title;
        Description = description;
        Duration = duration;
        ClosedQuestions = singleChoiceQuestions.Concat(multipleChoiceQuestions).ToArray();
        Questions = QuizSpecificationHelper.GetQuestions(openQuestions, singleChoiceQuestions, multipleChoiceQuestions);
        QuestionsCount = Questions.Count;
    }

    public int QuestionsCount { get; }
    public int QuestionsCountInRunningQuiz { get; }
    public AggregateId OwnerId { get; }
    public AggregateId UserId { get; }
    public string Title { get; }
    public string? Description { get; }
    public TimeSpan Duration { get; }
    public IReadOnlyCollection<QuizClosedQuestionCreateData> ClosedQuestions { get; }
    public IReadOnlyCollection<QuizQuestionSpecificationData> Questions { get; }
}