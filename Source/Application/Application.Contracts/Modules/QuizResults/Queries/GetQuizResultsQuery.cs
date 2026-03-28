using Application.Contracts.Modules.QuizResults.Dtos;
using LP.Common.Application.Contracts.CQRS;
using LP.Common.Application.Contracts.ReadModel;

namespace Application.Contracts.Modules.QuizResults.Queries;

public record GetQuizResultsQuery(PaginationData Pagination) : IQuery<PaginatedListDto<QuizResultsListItemDto>>;