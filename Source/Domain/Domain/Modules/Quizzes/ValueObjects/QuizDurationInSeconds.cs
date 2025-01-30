using Common.Domain.Exceptions;

namespace Domain.Modules.Quizzes.ValueObjects;

public readonly struct QuizDurationInSeconds
{
    private readonly int _durationInSeconds;

    public QuizDurationInSeconds(int durationInSeconds)
    {
        if (durationInSeconds < 60 || durationInSeconds > 60 * 180)
            throw new DomainLogicException(QuizMessages.IncorrectQuizDuration());

        _durationInSeconds = durationInSeconds;
    }

    public int ToInt() => _durationInSeconds;
}