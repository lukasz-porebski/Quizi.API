using Domain.Modules.Quizzes.Enums;

namespace Domain.Modules.Quizzes.ValueObjects;

public readonly struct QuizSettings
{
    public QuizDurationInSeconds DurationInSeconds { get; }
    public QuizQuestionsCountInRunningQuiz QuestionsCountInRunningQuiz { get; }
    public bool RandomQuestions { get; }
    public bool RandomAnswers { get; }
    public bool NegativePoints { get; }
    public QuizCopyMode QuizCopyMode { get; }

    public QuizSettings(QuizDurationInSeconds durationInSeconds,
        QuizQuestionsCountInRunningQuiz questionsCountInRunningQuiz,
        bool randomQuestions, bool randomAnswers, bool negativePoints,
        QuizCopyMode quizCopyMode)
    {
        DurationInSeconds = durationInSeconds;
        QuestionsCountInRunningQuiz = questionsCountInRunningQuiz;
        RandomQuestions = randomQuestions;
        RandomAnswers = randomAnswers;
        NegativePoints = negativePoints;
        QuizCopyMode = quizCopyMode;
    }
}