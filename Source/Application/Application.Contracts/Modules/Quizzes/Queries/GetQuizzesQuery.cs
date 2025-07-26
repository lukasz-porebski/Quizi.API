using Application.Contracts.Modules.Quizzes.Dtos;
using Common.Application.Contracts.CQRS;
using Common.Application.Contracts.ReadModel;

namespace Application.Contracts.Modules.Quizzes.Queries;

public record GetQuizzesQuery(PaginationData Pagination) : IQuery<PaginatedListDto<QuizzesListItemDto>>;