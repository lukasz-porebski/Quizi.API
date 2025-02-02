using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models;
using Domain.Modules.Quizzes.Helpers;
using Domain.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Models;

public class Quiz : BaseAggregateRoot
{
    private IQuizSpecificationFactory _specificationFactory = null!;
    private List<QuizOpenQuestion> _openQuestions = [];
    private List<QuizSingleChoiceQuestion> _singleChoiceQuestions = [];
    private List<QuizMultipleChoiceQuestion> _multipleChoiceQuestions = [];

    internal Quiz(QuizCreateData data, IQuizSpecificationFactory specificationFactory)
        : base(data.Id)
    {
        SetDependencies(specificationFactory);

        var specificationData = data.ToSpecificationData();
        _specificationFactory.QuizPersist(specificationData).ValidateAndThrow();

        OwnerId = data.Owner;
        Title = data.Title;
        Description = data.Description;
        Code = Guid.NewGuid();
        Settings = data.Settings;

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

        _openQuestions.Adjust(Id, data.OpenQuestions);
        _singleChoiceQuestions.Adjust(Id, data.SingleChoiceQuestions);
        _multipleChoiceQuestions.Adjust(Id, data.MultipleChoiceQuestions);
    }

    public void AddNewQuestions(QuizAddNewQuestionsData data)
    {
        _specificationFactory
            .AddNewQuestions(data.ToSpecificationData(OwnerId, OpenQuestions, SingleChoiceQuestions, MultipleChoiceQuestions))
            .ValidateAndThrow();

        if (!data.QuestionsCountInRunningQuiz.Equals(Settings.QuestionsCountInRunningQuiz))
            Settings = Settings with { QuestionsCountInRunningQuiz = data.QuestionsCountInRunningQuiz };

        _openQuestions = OpenQuestions.AddNewQuestions(Id, data.OpenQuestions);
        _singleChoiceQuestions = SingleChoiceQuestions.AddNewQuestions(Id, data.SingleChoiceQuestions);
        _multipleChoiceQuestions = MultipleChoiceQuestions.AddNewQuestions(Id, data.MultipleChoiceQuestions);
    }

    internal void SetDependencies(IQuizSpecificationFactory specificationFactory)
    {
        _specificationFactory = specificationFactory;
    }
}