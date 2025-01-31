using Common.Domain.Exceptions;
using Domain.Modules.Quizzes.Constants;

namespace Domain.Modules.Quizzes.ValueObjects;

public readonly struct QuizDurationInSeconds
{
    private readonly int _durationInSeconds;

    public QuizDurationInSeconds(int durationInSeconds)
    {
        if (durationInSeconds is < 60 or > 60 * 180)
            throw new DomainLogicException(QuizMessageCodes.IncorrectQuizDuration);

        _durationInSeconds = durationInSeconds;
    }

    public int ToInt() => _durationInSeconds;
}