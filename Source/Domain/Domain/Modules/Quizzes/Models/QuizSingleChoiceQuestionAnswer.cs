using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.Models.Base;

namespace Domain.Modules.Quizzes.Models;

public class QuizSingleChoiceQuestionAnswer : BaseQuizClosedQuestionAnswer
{
    internal QuizSingleChoiceQuestionAnswer(
        AggregateId id,
        EntityNo no,
        EntityNo subNo,
        QuizClosedQuestionAnswerPersistData data
    ) : base(id, no, subNo, data)
    {
    }

    private QuizSingleChoiceQuestionAnswer()
    {
    }
}