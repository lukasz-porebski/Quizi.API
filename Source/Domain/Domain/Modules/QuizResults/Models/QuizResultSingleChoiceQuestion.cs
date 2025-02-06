using Common.Domain.Entities;
using Common.Domain.Extensions;
using Common.Domain.ValueObjects;
using Domain.Modules.QuizResults.Data.Sub;

namespace Domain.Modules.QuizResults.Models;

public class QuizResultSingleChoiceQuestion : BaseEntity
{
    private readonly List<QuizResultSingleChoiceQuestionAnswer> _answers = [];

    internal QuizResultSingleChoiceQuestion(AggregateId id, EntityNo no, QuizResultSingleChoiceQuestionCreateDate data)
        : base(id, no)
    {
        OrdinalNumber = data.OrdinalNumber;
        Text = data.Text;
        ScoredPoints = data.ScoredPoints;
        PointsPossibleToGet = data.PointsPossibleToGet;
        _answers.ApplyNew(data.Answers, (subNo, a) => new QuizResultSingleChoiceQuestionAnswer(id, no, subNo, a));
    }

    private QuizResultSingleChoiceQuestion()
    {
    }

    public int OrdinalNumber { get; private set; }
    public string Text { get; private set; } = null!;
    public float ScoredPoints { get; private set; }
    public float PointsPossibleToGet { get; private set; }
    public IReadOnlyList<QuizResultSingleChoiceQuestionAnswer> Answers => _answers;
}