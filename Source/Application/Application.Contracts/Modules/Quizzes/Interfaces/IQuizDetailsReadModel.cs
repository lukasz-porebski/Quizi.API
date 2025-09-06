using Application.Contracts.Modules.Quizzes.Dtos;
using Application.Contracts.Modules.Quizzes.Queries;

namespace Application.Contracts.Modules.Quizzes.Interfaces;

public interface IQuizDetailsReadModel
{
    Task<QuizDetailsDto> Get(GetQuizDetailsQuery query, CancellationToken cancellationToken);
}