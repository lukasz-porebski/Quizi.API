using Application.Contracts.Modules.Quizzes.Dtos;
using Application.Contracts.Modules.Quizzes.Queries;
using Common.Application.Contracts.ReadModel;

namespace Application.Contracts.Modules.Quizzes.Interfaces;

public interface IQuizzesReadModel
{
    Task<PaginatedListDto<QuizzesListItemDto>> Get(GetQuizzesQuery query, CancellationToken cancellationToken);
}