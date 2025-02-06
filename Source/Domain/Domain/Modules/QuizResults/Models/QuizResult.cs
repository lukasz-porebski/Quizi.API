using Common.Domain.Entities;
using Common.Domain.Extensions;
using Common.Domain.ValueObjects;
using Common.Shared.DataStructures;
using Domain.Modules.QuizResults.Data;

namespace Domain.Modules.QuizResults.Models;

public class QuizResult : BaseAggregateRoot
{
    private readonly List<QuizResultOpenQuestion> _openQuestions = [];
    private readonly List<QuizResultSingleChoiceQuestion> _singleChoiceQuestions = [];
    private readonly List<QuizResultMultipleChoiceQuestion> _multipleChoiceQuestions = [];

    internal QuizResult(AggregateId id, QuizResultCreateData data) : base(id)
    {
        //TODO: Dodać walidacje

        QuizId = data.Quiz.Id;
        UserId = data.UserId;
        Title = data.Title;
        QuizRunningPeriod = data.QuizRunningPeriod;
        Duration = data.Duration;
        NegativePoints = data.NegativePoints;
        RandomQuestions = data.RandomQuestions;
        RandomAnswers = data.RandomAnswers;
        _openQuestions.ApplyNew(data.OpenQuestions, (no, a) => new QuizResultOpenQuestion(id, no, a));
        _singleChoiceQuestions.ApplyNew(data.SingleChoiceQuestions, (no, a) => new QuizResultSingleChoiceQuestion(id, no, a));
        _multipleChoiceQuestions.ApplyNew(data.MultipleChoiceQuestions, (no, a) => new QuizResultMultipleChoiceQuestion(id, no, a));
    }

    private QuizResult()
    {
    }

    public AggregateId QuizId { get; private set; } = null!;
    public AggregateId UserId { get; private set; } = null!;
    public string Title { get; private set; } = null!;
    public Period<DateTime> QuizRunningPeriod { get; private set; } = null!;
    public TimeSpan Duration { get; private set; }
    public bool NegativePoints { get; private set; }
    public bool RandomQuestions { get; private set; }
    public bool RandomAnswers { get; private set; }
    public IReadOnlyCollection<QuizResultOpenQuestion> OpenQuestions => _openQuestions;
    public IReadOnlyCollection<QuizResultSingleChoiceQuestion> SingleChoiceQuestions => _singleChoiceQuestions;
    public IReadOnlyCollection<QuizResultMultipleChoiceQuestion> MultipleChoiceQuestions => _multipleChoiceQuestions;
}