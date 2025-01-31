using Common.Domain.ValueObjects;

namespace Domain.Modules.Quizzes.Interfaces;

public interface IQuizQuestionUpdateData : IQuizQuestionData
{
    EntityNo? EntityNo { get; }
}