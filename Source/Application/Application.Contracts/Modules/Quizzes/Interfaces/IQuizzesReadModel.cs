using Application.Contracts.Modules.Quizzes.Dtos;
using Application.Contracts.Modules.Quizzes.Queries;
using Common.Application.Contracts.ReadModel;
using Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.Quizzes.Interfaces;

public interface IQuizzesReadModel
{
    Task<PaginatedListDto<QuizzesListItemDto>> Get(
        GetQuizzesQuery query, AggregateId userId, CancellationToken cancellationToken);
}