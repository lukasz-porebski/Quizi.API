using Common.Domain.Exceptions;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Extensions;

namespace Domain.Modules.Quizzes.ValueObjects;

public readonly struct QuizQuestionOrderedAnswer_TO_REMOVE
{
    public int OrderNumber { get; }
    public string Text { get; }

    private const int MinValue = 1;

    public QuizQuestionOrderedAnswer_TO_REMOVE(int orderNumber, string text)
    {
        if (orderNumber < MinValue)
            throw new DomainLogicException(QuizMessageCodes.AnswerOrderNumberLessThanOne);

        if (text.IsEmpty())
            throw new DomainLogicException(QuizMessageCodes.AnswerIsEmpty);

        OrderNumber = orderNumber;
        Text = text.RemoveIllegalWhiteSpaces();
    }
}