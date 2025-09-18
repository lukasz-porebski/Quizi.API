using Application.Contracts.Modules.Quizzes.Dtos;
using Application.Contracts.Modules.QuizzesVerification.Queries;

namespace Application.Contracts.Modules.QuizzesVerification.Interfaces;

public interface IQuizToRunReadModel
{
    Task<QuizToRunDto> Get(GetQuizToRunQuery query, CancellationToken cancellationToken);
}