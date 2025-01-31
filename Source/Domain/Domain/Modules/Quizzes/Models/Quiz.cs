using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models;
using Domain.Modules.Quizzes.Data.Specifications;
using Domain.Modules.Quizzes.Helpers;
using Domain.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Models;

public class Quiz : BaseAggregateRoot
{
    private IQuizSpecificationFactory _quizSpecificationFactory = null!;
    private readonly List<AggregateId> _users = [];
    private List<QuizOpenQuestion> _openQuestions = [];
    private List<QuizSingleChoiceQuestion> _singleChoiceQuestions = [];
    private List<QuizMultipleChoiceQuestion> _multipleChoiceQuestions = [];

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
        _openQuestions = data.OpenQuestions.ToEntities(Id);
        _singleChoiceQuestions = data.SingleChoiceQuestions.ToEntities(Id);
        _multipleChoiceQuestions = data.MultipleChoiceQuestions.ToEntities(Id);
    }

    private Quiz()
    {
    }

    public AggregateId OwnerId { get; } = null!;
    public string Title { get; private set; } = null!;
    public string? Description { get; private set; }
    public Guid Code { get; private set; }
    public QuizSettings Settings { get; private set; } = null!;
    public IReadOnlyList<AggregateId> Users => _users;
    public IReadOnlyList<QuizOpenQuestion> OpenQuestions => _openQuestions;
    public IReadOnlyList<QuizSingleChoiceQuestion> SingleChoiceQuestions => _singleChoiceQuestions;
    public IReadOnlyList<QuizMultipleChoiceQuestion> MultipleChoiceQuestions => _multipleChoiceQuestions;

    public void Update(QuizUpdateData data)
    {
        _quizSpecificationFactory.QuizPersist(data.ToSpecificationData(OwnerId)).ValidateAndThrow();

        Title = data.Title;
        Description = data.Description;

        if (!Settings.Equals(data.Settings))
            Settings = data.Settings;

        _openQuestions.Adjust(Id, data.OpenQuestions);
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
                OwnerId, OpenQuestions, SingleChoiceQuestions, MultipleChoiceQuestions))
            .ValidateAndThrow();

        if (!data.QuestionsCountInRunningQuiz.Equals(Settings.QuestionsCountInRunningQuiz))
            Settings = new QuizSettings(
                Duration: Settings.Duration,
                QuestionsCountInRunningQuiz: data.QuestionsCountInRunningQuiz,
                RandomAnswers: Settings.RandomAnswers,
                RandomQuestions: Settings.RandomQuestions,
                NegativePoints: Settings.NegativePoints,
                QuizCopyMode: Settings.QuizCopyMode);

        _openQuestions = OpenQuestions.AddNewQuestions(Id, data.OpenQuestions);
        _singleChoiceQuestions = SingleChoiceQuestions.AddNewQuestions(Id, data.SingleChoiceQuestions);
        _multipleChoiceQuestions = MultipleChoiceQuestions.AddNewQuestions(Id, data.MultipleChoiceQuestions);
    }

    internal void SetDependencies(IQuizSpecificationFactory quizSpecificationFactory)
    {
        _quizSpecificationFactory = quizSpecificationFactory;
    }
}