using Common.Domain.Entities;
using Common.Domain.Extensions;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models;
using Domain.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Models;

public class Quiz : BaseAggregateRoot
{
    private readonly List<QuizOpenQuestion> _openQuestions = [];
    private readonly List<QuizSingleChoiceQuestion> _singleChoiceQuestions = [];
    private readonly List<QuizMultipleChoiceQuestion> _multipleChoiceQuestions = [];

    private IQuizSpecificationFactory _specificationFactory = null!;

    internal Quiz(
        AggregateId id,
        QuizCreateData data,
        IQuizSpecificationFactory specificationFactory)
        : base(id)
    {
        SetDependencies(specificationFactory);

        var specificationData = data.ToSpecificationData(data.OwnerId);
        _specificationFactory.QuizPersist(specificationData).ValidateAndThrow();

        OwnerId = data.OwnerId;
        Title = data.Title;
        Description = data.Description;
        Code = Guid.NewGuid();
        Settings = data.Settings;
        _openQuestions.ApplyNew(data.OpenQuestions, (no, a) => new QuizOpenQuestion(id, no, a));
        _singleChoiceQuestions.ApplyNew(data.SingleChoiceQuestions, (no, a) => new QuizSingleChoiceQuestion(id, no, a));
        _multipleChoiceQuestions.ApplyNew(data.MultipleChoiceQuestions, (no, a) => new QuizMultipleChoiceQuestion(id, no, a));
    }

    private Quiz()
    {
    }

    public AggregateId OwnerId { get; } = null!;
    public string Title { get; private set; } = null!;
    public string? Description { get; private set; }
    public Guid Code { get; private set; }
    public QuizSettings Settings { get; private set; } = null!;
    public IReadOnlyList<QuizOpenQuestion> OpenQuestions => _openQuestions;
    public IReadOnlyList<QuizSingleChoiceQuestion> SingleChoiceQuestions => _singleChoiceQuestions;
    public IReadOnlyList<QuizMultipleChoiceQuestion> MultipleChoiceQuestions => _multipleChoiceQuestions;

    public void Update(QuizUpdateData data)
    {
        _specificationFactory.QuizPersist(data.ToSpecificationData(OwnerId)).ValidateAndThrow();

        Title = data.Title;
        Description = data.Description;

        if (!Settings.Equals(data.Settings))
            Settings = data.Settings;

        _openQuestions.ApplyChanges(
            data.OpenQuestions,
            (no, d) => new QuizOpenQuestion(Id, no, d.Data),
            (q, d) => q.Update(d.Data));
        _singleChoiceQuestions.ApplyChanges(
            data.SingleChoiceQuestions,
            (no, d) => new QuizSingleChoiceQuestion(Id, no, d.Data.ToCreateData()),
            (q, d) => q.Update(d.Data));
        _multipleChoiceQuestions.ApplyChanges(
            data.MultipleChoiceQuestions,
            (no, d) => new QuizMultipleChoiceQuestion(Id, no, d.Data.ToCreateData()),
            (q, d) => q.Update(d.Data));
    }

    public void AddNewQuestions(QuizAddNewQuestionsData data)
    {
        _specificationFactory
            .AddNewQuestions(data.ToSpecificationData(OwnerId, OpenQuestions, SingleChoiceQuestions, MultipleChoiceQuestions))
            .ValidateAndThrow();

        if (!data.QuestionsCountInRunningQuiz.Equals(Settings.QuestionsCountInRunningQuiz))
            Settings = Settings with { QuestionsCountInRunningQuiz = data.QuestionsCountInRunningQuiz };

        _openQuestions.ApplyNew(
            data.OpenQuestions,
            (no, persistData) => new QuizOpenQuestion(Id, no, persistData));

        _singleChoiceQuestions.ApplyNew(
            data.SingleChoiceQuestions,
            (no, persistData) => new QuizSingleChoiceQuestion(Id, no, persistData));

        _multipleChoiceQuestions.ApplyNew(
            data.SingleChoiceQuestions,
            (no, persistData) => new QuizMultipleChoiceQuestion(Id, no, persistData));
    }

    internal void SetDependencies(IQuizSpecificationFactory specificationFactory)
    {
        _specificationFactory = specificationFactory;
    }
}