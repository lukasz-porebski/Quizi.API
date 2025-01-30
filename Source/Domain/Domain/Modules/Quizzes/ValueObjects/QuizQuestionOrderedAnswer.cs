using Common.Domain.Exceptions;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Extensions;

namespace Domain.Modules.Quizzes.ValueObjects;

public readonly struct QuizQuestionOrderedAnswer
{
    public int OrderNumber { get; }
    public string Text { get; }

    private const int MinValue = 1;

    public QuizQuestionOrderedAnswer(int orderNumber, string text)
    {
        if (orderNumber < MinValue)
            throw new DomainLogicException(QuizMessages.AnswerOrderNumberLessThanOne());

        if (text.IsEmpty())
            throw new DomainLogicException(QuizMessages.AnswerIsEmpty());

        OrderNumber = orderNumber;
        Text = text.RemoveIllegalWhiteSpaces();
    }
}