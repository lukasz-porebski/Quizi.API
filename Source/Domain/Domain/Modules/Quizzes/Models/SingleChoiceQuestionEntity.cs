using Common.Domain.ValueObjects;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Data.Questions.Create;
using Domain.Modules.Quizzes.Data.Questions.Update;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Models;

public class SingleChoiceQuestionEntity : QuizQuestionBaseEntity
{
    public QuizQuestionOrderedAnswer CorrectAnswer { get; private set; }

    private List<QuizQuestionOrderedAnswer> _wrongAnswers;
    public IReadOnlyList<QuizQuestionOrderedAnswer> WrongAnswers => _wrongAnswers;

    internal SingleChoiceQuestionEntity(EntityNo no, QuizSingleChoiceQuestionCreateData createData)
    {
        No = no;
        OrderNumber = createData.OrderNumber;
        Text = createData.Text;
        CorrectAnswer = createData.CorrectAnswer;
        _wrongAnswers = createData.WrongAnswers;
    }

    internal void Update(QuizSingleChoiceQuestionUpdateData updateData)
    {
        if (OrderNumber.Equals(updateData.OrderNumber) &&
            Text.Equals(updateData.Text) &&
            CorrectAnswer.Equals(updateData.CorrectAnswer) &&
            WrongAnswers.CollectionEqual(updateData.WrongAnswers))
            return;

        OrderNumber = updateData.OrderNumber;
        Text = updateData.Text;
        CorrectAnswer = updateData.CorrectAnswer;
        _wrongAnswers = updateData.WrongAnswers;
    }

    private SingleChoiceQuestionEntity()
    {
        _wrongAnswers = new List<QuizQuestionOrderedAnswer>();
    }
}