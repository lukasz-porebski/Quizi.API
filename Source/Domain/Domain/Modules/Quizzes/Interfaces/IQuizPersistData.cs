using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Interfaces;

public interface IQuizPersistData
{
    AggregateId OwnerId { get; }
    string Title { get; }
    string? Description { get; }
    QuizSettings Settings { get; }
    IReadOnlyCollection<QuizOpenQuestionPersistData> OpenQuestions { get; }
    IReadOnlyCollection<QuizClosedQuestionCreateData> SingleChoiceQuestions { get; }
    IReadOnlyCollection<QuizClosedQuestionCreateData> MultipleChoiceQuestions { get; }
}