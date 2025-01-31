using Common.Domain.Exceptions;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Extensions;

namespace Domain.Modules.Quizzes.ValueObjects;

public readonly struct QuizDescription
{
    private readonly string _description;

    public QuizDescription(string description)
    {
        const int maxNumberOfCharacters = 200;

        var trimmedDescription = description.RemoveIllegalWhiteSpaces();

        if (trimmedDescription.Any() && trimmedDescription.Length > maxNumberOfCharacters)
            throw new DomainLogicException(QuizMessageCodes.IncorrectDescriptionLength);

        _description = trimmedDescription;
    }
}