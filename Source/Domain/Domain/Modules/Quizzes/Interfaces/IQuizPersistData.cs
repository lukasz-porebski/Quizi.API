using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.ValueObjects;
using LP.Common.Domain.ValueObjects;

namespace Domain.Modules.Quizzes.Interfaces;

public interface IQuizPersistData
{
    AggregateId OwnerId { get; }
    string Title { get; }
    string? Description { get; }
    QuizSettings Settings { get; }
    IReadOnlyCollection<QuizPersistOpenQuestionData> OpenQuestions { get; }
    IReadOnlyCollection<QuizClosedQuestionCreateData> SingleChoiceQuestions { get; }
    IReadOnlyCollection<QuizClosedQuestionCreateData> MultipleChoiceQuestions { get; }
}