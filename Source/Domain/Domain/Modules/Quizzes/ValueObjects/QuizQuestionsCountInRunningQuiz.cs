using Common.Domain.Exceptions;
using Domain.Modules.Quizzes.Constants;

namespace Domain.Modules.Quizzes.ValueObjects;

public readonly struct QuizQuestionsCountInRunningQuiz
{
    private readonly int _questionsCountInRunningQuiz;

    public QuizQuestionsCountInRunningQuiz(int questionsCountInRunningQuiz, int questionsCount)
    {
        if (questionsCountInRunningQuiz < 1 || questionsCountInRunningQuiz > questionsCount)
            throw new DomainLogicException(QuizMessageCodes.QuizIncorrectDefinedQuestionsCountInRunningQuiz);

        _questionsCountInRunningQuiz = questionsCountInRunningQuiz;
    }

    public bool Equals(QuizQuestionsCountInRunningQuiz other) =>
        _questionsCountInRunningQuiz == other._questionsCountInRunningQuiz;

    public int ToInt() => _questionsCountInRunningQuiz;
}