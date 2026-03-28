using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.Models.Base;
using LP.Common.Domain.ValueObjects;

namespace Domain.Modules.Quizzes.Models;

public class QuizMultipleChoiceQuestionAnswer : BaseQuizClosedQuestionAnswer
{
    internal QuizMultipleChoiceQuestionAnswer(
        AggregateId id,
        EntityNo no,
        EntityNo subNo,
        QuizPersistClosedQuestionAnswerData data
    ) : base(id, no, subNo, data)
    {
    }

    private QuizMultipleChoiceQuestionAnswer()
    {
    }
}