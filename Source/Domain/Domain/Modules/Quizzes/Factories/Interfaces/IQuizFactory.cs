using Domain.Modules.Quizzes.Data;
using Domain.Modules.Quizzes.Models;

namespace Domain.Modules.Quizzes.Factories.Interfaces;

public interface IQuizFactory
{
    Quiz Create(QuizCreateData data);
}