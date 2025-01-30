using Common.Domain.Exceptions;

namespace Domain.Modules.Quizzes.ValueObjects;

public readonly struct QuizQuestionsCountInRunningQuiz
{
    private readonly int _questionsCountInRunningQuiz;

    public QuizQuestionsCountInRunningQuiz(int questionsCountInRunningQuiz, int questionsCount)
    {
        if (questionsCountInRunningQuiz < 1 || questionsCountInRunningQuiz > questionsCount)
            throw new DomainLogicException(QuizMessages.QuizIncorrectDefinedQuestionsCountInRunningQuiz());

        _questionsCountInRunningQuiz = questionsCountInRunningQuiz;
    }

    public bool Equals(QuizQuestionsCountInRunningQuiz other) =>
        _questionsCountInRunningQuiz == other._questionsCountInRunningQuiz;

    public int ToInt() => _questionsCountInRunningQuiz;
}