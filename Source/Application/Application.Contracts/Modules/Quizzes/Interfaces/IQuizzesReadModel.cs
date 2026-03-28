using Application.Contracts.Modules.Quizzes.Dtos;
using Application.Contracts.Modules.Quizzes.Queries;
using LP.Common.Application.Contracts.ReadModel;
using LP.Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.Quizzes.Interfaces;

public interface IQuizzesReadModel
{
    Task<PaginatedListDto<QuizzesListItemDto>> Get(
        GetQuizzesQuery query, AggregateId userId, CancellationToken cancellationToken);
}