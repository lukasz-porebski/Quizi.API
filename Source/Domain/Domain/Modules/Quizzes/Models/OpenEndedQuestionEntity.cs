using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Questions.Create;
using Domain.Modules.Quizzes.Data.Questions.Update;

namespace Domain.Modules.Quizzes.Models;

public class OpenEndedQuestionEntity : QuizQuestionBaseEntity
{
    public string CorrectAnswer { get; private set; }

    private OpenEndedQuestionEntity()
    {
    }

    internal OpenEndedQuestionEntity(EntityNo no, QuizOpenEndedQuestionCreateData createData)
    {
        No = no;
        OrderNumber = createData.OrderNumber;
        Text = createData.Text;
        CorrectAnswer = createData.CorrectAnswer;
    }

    internal void Update(QuizOpenEndedQuestionUpdateData updateData)
    {
        if (OrderNumber.Equals(updateData.OrderNumber)
            && Text.Equals(updateData.Text)
            && CorrectAnswer.Equals(updateData.CorrectAnswer))
            return;

        OrderNumber = updateData.OrderNumber;
        Text = updateData.Text;
        CorrectAnswer = updateData.CorrectAnswer;
    }
}