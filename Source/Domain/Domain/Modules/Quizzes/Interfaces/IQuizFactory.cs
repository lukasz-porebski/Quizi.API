using Domain.Modules.Quizzes.Data.Models;
using Domain.Modules.Quizzes.Models;

namespace Domain.Modules.Quizzes.Interfaces;

public interface IQuizFactory
{
    Quiz Create(QuizCreateData data);
}