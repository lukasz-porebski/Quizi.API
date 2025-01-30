using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data;
using Domain.Modules.Quizzes.Factories.Interfaces;
using Domain.Modules.Quizzes.Helpers;
using Domain.Modules.Quizzes.Specifications.Data;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Models;

public class Quiz : BaseAggregateRoot
{
    private IQuizSpecificationFactory _quizSpecificationFactory;
    private readonly List<AggregateId> _users = [];
    private List<OpenEndedQuestionEntity> _openEndedQuestions = [];
    private List<SingleChoiceQuestionEntity> _singleChoiceQuestions = [];
    private List<MultipleChoiceQuestionEntity> _multipleChoiceQuestions = [];

    public AggregateId OwnerId { get; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Guid Code { get; private set; }
    public QuizSettings Settings { get; private set; }
    public IReadOnlyList<AggregateId> Users => _users;
    public IReadOnlyList<OpenEndedQuestionEntity> OpenEndedQuestions => _openEndedQuestions;
    public IReadOnlyList<SingleChoiceQuestionEntity> SingleChoiceQuestions => _singleChoiceQuestions;
    public IReadOnlyList<MultipleChoiceQuestionEntity> MultipleChoiceQuestions => _multipleChoiceQuestions;

    private QuizAggregateRoot()
    {
    }

    internal QuizAggregateRoot(IQuizSpecificationFactory quizSpecificationFactory, QuizCreateData data)
    {
        SetDependencies(quizSpecificationFactory);

        var specificationData = data.ToSpecificationData();
        _quizSpecificationFactory.QuizPersist(specificationData).Validate();

        Id = data.Id;
        OwnerId = data.Owner;
        Title = data.Title;
        Description = data.Description;
        Code = Guid.NewGuid();
        Settings = data.Settings;

        _users = new List<AggregateId> { OwnerId };
        _openEndedQuestions = data.OpenEndedQuestions.ToEntities();
        _singleChoiceQuestions = data.SingleChoiceQuestions.ToEntities();
        _multipleChoiceQuestions = data.MultipleChoiceQuestions.ToEntities();
    }

    public void Update(QuizUpdateData data)
    {
        _quizSpecificationFactory.QuizPersist(data.ToSpecificationData(OwnerId)).Validate();

        Title = data.Title;
        Description = data.Description;

        if (!Settings.Equals(data.Settings))
            Settings = data.Settings;

        _openEndedQuestions.Adjust(data.OpenEndedQuestions);
        _singleChoiceQuestions.Adjust(data.SingleChoiceQuestions);
        _multipleChoiceQuestions.Adjust(data.MultipleChoiceQuestions);
    }

    public void AddUser(AggregateId ownerId, AggregateId userId)
    {
        var specificationData = new QuizAddUserSpecificationData(
            _users, userId, OwnerId, ownerId);

        _quizSpecificationFactory.AddUser(specificationData).Validate();

        _users.Add(userId);
    }

    public void RemoveUser(AggregateId ownerId, AggregateId userIdToRemove)
    {
        var specificationData = new QuizRemoveUserSpecificationData(
            _users, OwnerId, ownerId, userIdToRemove);

        _quizSpecificationFactory.RemoveUser(specificationData).Validate();

        _users.Remove(userIdToRemove);
    }

    public void AddNewQuestions(QuizAddNewQuestionsData data)
    {
        _quizSpecificationFactory
            .AddNewQuestions(data.ToSpecificationData(
                OwnerId, OpenEndedQuestions, SingleChoiceQuestions, MultipleChoiceQuestions))
            .Validate();

        if (!data.QuestionsCountInRunningQuiz.Equals(Settings.QuestionsCountInRunningQuiz))
            Settings = new QuizSettings(
                durationInSeconds: Settings.DurationInSeconds,
                questionsCountInRunningQuiz: data.QuestionsCountInRunningQuiz,
                randomAnswers: Settings.RandomAnswers,
                randomQuestions: Settings.RandomQuestions,
                negativePoints: Settings.NegativePoints,
                quizCopyMode: Settings.QuizCopyMode);

        _openEndedQuestions = OpenEndedQuestions.AddNewQuestions(data.OpenEndedQuestions);
        _singleChoiceQuestions = SingleChoiceQuestions.AddNewQuestions(data.SingleChoiceQuestions);
        _multipleChoiceQuestions = MultipleChoiceQuestions.AddNewQuestions(data.MultipleChoiceQuestions);
    }

    internal void SetDependencies(IQuizSpecificationFactory quizSpecificationFactory)
    {
        _quizSpecificationFactory = quizSpecificationFactory;
    }
}