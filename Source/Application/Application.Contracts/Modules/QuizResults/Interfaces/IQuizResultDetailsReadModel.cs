using Application.Contracts.Modules.QuizResults.Dtos;
using Application.Contracts.Modules.QuizResults.Queries;

namespace Application.Contracts.Modules.QuizResults.Interfaces;

public interface IQuizResultDetailsReadModel
{
    Task<QuizResultDetailsDto> Get(GetQuizResultDetailsQuery query, CancellationToken cancellationToken);
}