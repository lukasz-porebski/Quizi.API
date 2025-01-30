using Common.Domain.ValueObjects;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Data.Questions.Create;
using Domain.Modules.Quizzes.Data.Questions.Update;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Models;

public class SingleChoiceQuestion : BaseQuizQuestion
{
    private readonly List<QuizQuestionOrderedAnswer> _wrongAnswers = [];

    public QuizQuestionOrderedAnswer CorrectAnswer { get; private set; }
    public IReadOnlyList<QuizQuestionOrderedAnswer> WrongAnswers => _wrongAnswers;

    internal SingleChoiceQuestion(AggregateId id, EntityNo no, QuizSingleChoiceQuestionCreateData data)
        : base(id, no, data)
    {
        CorrectAnswer = data.CorrectAnswer;
        _wrongAnswers.Set(data.WrongAnswers);
    }

    private SingleChoiceQuestion()
    {
    }

    internal void Update(QuizSingleChoiceQuestionUpdateData data)
    {
        if (OrderNumber.Equals(data.OrderNumber) &&
            Text.Equals(data.Text) &&
            CorrectAnswer.Equals(data.CorrectAnswer) &&
            WrongAnswers.CollectionEqual(data.WrongAnswers))
            return;

        base.Update(data);
        CorrectAnswer = data.CorrectAnswer;
        _wrongAnswers.Set(data.WrongAnswers);
    }
}