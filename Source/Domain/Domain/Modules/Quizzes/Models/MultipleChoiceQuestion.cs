using Common.Domain.ValueObjects;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Data.Questions.Create;
using Domain.Modules.Quizzes.Data.Questions.Update;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Models;

public class MultipleChoiceQuestion : BaseQuizQuestion
{
    private readonly List<QuizQuestionOrderedAnswer> _correctAnswers = [];
    private readonly List<QuizQuestionOrderedAnswer> _wrongAnswers = [];

    public IReadOnlyList<QuizQuestionOrderedAnswer> CorrectAnswers => _correctAnswers;
    public IReadOnlyList<QuizQuestionOrderedAnswer> WrongAnswers => _wrongAnswers;

    internal MultipleChoiceQuestion(AggregateId id, EntityNo no, QuizMultipleChoiceQuestionCreateData data)
        : base(id, no, data)
    {
        _correctAnswers = data.CorrectAnswers.ToList();
        _wrongAnswers = data.WrongAnswers.ToList();
    }

    private MultipleChoiceQuestion()
    {
    }

    internal void Update(QuizMultipleChoiceQuestionUpdateData data)
    {
        if (OrderNumber.Equals(data.OrderNumber) &&
            Text.Equals(data.Text) &&
            _correctAnswers.CollectionEqual(data.CorrectAnswers) &&
            _wrongAnswers.CollectionEqual(data.WrongAnswers))
            return;

        base.Update(data);
        _correctAnswers.Set(data.CorrectAnswers);
        _wrongAnswers.Set(data.WrongAnswers);
    }
}