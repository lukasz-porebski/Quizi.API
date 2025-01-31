using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data;
using Domain.Modules.Quizzes.Data.Specifications;
using Domain.Modules.Quizzes.Factories.Interfaces;
using Domain.Modules.Quizzes.Helpers;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Models;

public class Quiz : BaseAggregateRoot
{
    private IQuizSpecificationFactory _quizSpecificationFactory = null!;
    private readonly List<AggregateId> _users = [];
    private List<OpenEndedQuestion> _openEndedQuestions = [];
    private List<SingleChoiceQuestion> _singleChoiceQuestions = [];
    private List<MultipleChoiceQuestion> _multipleChoiceQuestions = [];

    public AggregateId OwnerId { get; } = null!;
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public Guid Code { get; private set; }
    public QuizSettings Settings { get; private set; } = null!;
    public IReadOnlyList<AggregateId> Users => _users;
    public IReadOnlyList<OpenEndedQuestion> OpenEndedQuestions => _openEndedQuestions;
    public IReadOnlyList<SingleChoiceQuestion> SingleChoiceQuestions => _singleChoiceQuestions;
    public IReadOnlyList<MultipleChoiceQuestion> MultipleChoiceQuestions => _multipleChoiceQuestions;

    internal Quiz(IQuizSpecificationFactory quizSpecificationFactory, QuizCreateData data)
        : base(data.Id)
    {
        SetDependencies(quizSpecificationFactory);

        var specificationData = data.ToSpecificationData();
        _quizSpecificationFactory.QuizPersist(specificationData).ValidateAndThrow();

        OwnerId = data.Owner;
        Title = data.Title;
        Description = data.Description;
        Code = Guid.NewGuid();
        Settings = data.Settings;

        _users = [OwnerId];
        _openEndedQuestions = data.OpenEndedQuestions.ToEntities(Id);
        _singleChoiceQuestions = data.SingleChoiceQuestions.ToEntities(Id);
        _multipleChoiceQuestions = data.MultipleChoiceQuestions.ToEntities(Id);
    }

    private Quiz()
    {
    }

    public void Update(QuizUpdateData data)
    {
        _quizSpecificationFactory.QuizPersist(data.ToSpecificationData(OwnerId)).ValidateAndThrow();

        Title = data.Title;
        Description = data.Description;

        if (!Settings.Equals(data.Settings))
            Settings = data.Settings;

        _openEndedQuestions.Adjust(Id, data.OpenEndedQuestions);
        _singleChoiceQuestions.Adjust(Id, data.SingleChoiceQuestions);
        _multipleChoiceQuestions.Adjust(Id, data.MultipleChoiceQuestions);
    }

    public void AddUser(AggregateId ownerId, AggregateId userId)
    {
        var specificationData = new QuizAddUserSpecificationData(
            _users, userId, OwnerId, ownerId);

        _quizSpecificationFactory.AddUser(specificationData).ValidateAndThrow();

        _users.Add(userId);
    }

    public void RemoveUser(AggregateId ownerId, AggregateId userIdToRemove)
    {
        var specificationData = new QuizRemoveUserSpecificationData(
            _users, OwnerId, ownerId, userIdToRemove);

        _quizSpecificationFactory.RemoveUser(specificationData).ValidateAndThrow();

        _users.Remove(userIdToRemove);
    }

    public void AddNewQuestions(QuizAddNewQuestionsData data)
    {
        _quizSpecificationFactory
            .AddNewQuestions(data.ToSpecificationData(
                OwnerId, OpenEndedQuestions, SingleChoiceQuestions, MultipleChoiceQuestions))
            .ValidateAndThrow();

        if (!data.QuestionsCountInRunningQuiz.Equals(Settings.QuestionsCountInRunningQuiz))
            Settings = new QuizSettings(
                Duration: Settings.Duration,
                QuestionsCountInRunningQuiz: data.QuestionsCountInRunningQuiz,
                RandomAnswers: Settings.RandomAnswers,
                RandomQuestions: Settings.RandomQuestions,
                NegativePoints: Settings.NegativePoints,
                QuizCopyMode: Settings.QuizCopyMode);

        _openEndedQuestions = OpenEndedQuestions.AddNewQuestions(Id, data.OpenEndedQuestions);
        _singleChoiceQuestions = SingleChoiceQuestions.AddNewQuestions(Id, data.SingleChoiceQuestions);
        _multipleChoiceQuestions = MultipleChoiceQuestions.AddNewQuestions(Id, data.MultipleChoiceQuestions);
    }

    internal void SetDependencies(IQuizSpecificationFactory quizSpecificationFactory)
    {
        _quizSpecificationFactory = quizSpecificationFactory;
    }
}