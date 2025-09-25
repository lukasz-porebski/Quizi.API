using Application.Contracts.Modules.QuizResults.Dtos;
using Common.Application.Contracts.CQRS;
using Common.Application.Contracts.ReadModel;

namespace Application.Contracts.Modules.QuizResults.Queries;

public record GetQuizResultsQuery(PaginationData Pagination) : IQuery<PaginatedListDto<QuizResultsListItemDto>>;