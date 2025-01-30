using Common.Domain.Entities;

namespace Domain.Modules.Quizzes.Models;

public abstract class QuizQuestionBaseEntity : BaseEntity
{
    public int OrderNumber { get; protected set; }
    public string Text { get; protected set; }
}