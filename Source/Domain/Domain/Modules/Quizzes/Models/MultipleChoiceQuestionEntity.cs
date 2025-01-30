using Common.Domain.ValueObjects;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Data.Questions.Create;
using Domain.Modules.Quizzes.Data.Questions.Update;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Models;

public class MultipleChoiceQuestionEntity : QuizQuestionBaseEntity
{
    private List<QuizQuestionOrderedAnswer> _correctAnswers;
    public IReadOnlyList<QuizQuestionOrderedAnswer> CorrectAnswers => _correctAnswers;

    private List<QuizQuestionOrderedAnswer> _wrongAnswers;
    public IReadOnlyList<QuizQuestionOrderedAnswer> WrongAnswers => _wrongAnswers;

    internal MultipleChoiceQuestionEntity(EntityNo no, QuizMultipleChoiceQuestionCreateData createData)
    {
        No = no;
        OrderNumber = createData.OrderNumber;
        Text = createData.Text;
        _correctAnswers = createData.CorrectAnswers.ToList();
        _wrongAnswers = createData.WrongAnswers.ToList();
    }

    internal void Update(QuizMultipleChoiceQuestionUpdateData updateData)
    {
        if (OrderNumber.Equals(updateData.OrderNumber) &&
            Text.Equals(updateData.Text) &&
            _correctAnswers.CollectionEqual(updateData.CorrectAnswers) &&
            _wrongAnswers.CollectionEqual(updateData.WrongAnswers))
            return;

        OrderNumber = updateData.OrderNumber;
        Text = updateData.Text;
        _correctAnswers = updateData.CorrectAnswers;
        _wrongAnswers = updateData.WrongAnswers;
    }

    private MultipleChoiceQuestionEntity()
    {
        _correctAnswers = new List<QuizQuestionOrderedAnswer>();
        _wrongAnswers = new List<QuizQuestionOrderedAnswer>();
    }
}