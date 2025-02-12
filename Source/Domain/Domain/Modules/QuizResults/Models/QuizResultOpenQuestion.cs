using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Domain.Modules.QuizResults.Data.Sub;

namespace Domain.Modules.QuizResults.Models;

public class QuizResultOpenQuestion : BaseEntity
{
    internal QuizResultOpenQuestion(AggregateId id, EntityNo no, QuizResultOpenQuestionCreateData data)
        : base(id, no)
    {
        OrdinalNumber = data.OrdinalNumber;
        Text = data.Text;
        CorrectAnswer = data.CorrectAnswer;
        GivenAnswer = data.GivenAnswer;
        ScoredPoints = data.ScoredPoints;
        PointsPossibleToGet = data.PointsPossibleToGet;
        IsCorrect = data.IsCorrect;
    }

    private QuizResultOpenQuestion()
    {
    }

    public int OrdinalNumber { get; private set; }
    public string Text { get; private set; } = null!;
    public string CorrectAnswer { get; private set; } = null!;
    public string GivenAnswer { get; private set; } = null!;
    public float ScoredPoints { get; private set; }
    public float PointsPossibleToGet { get; private set; }
    public bool? IsCorrect { get; private set; }
}