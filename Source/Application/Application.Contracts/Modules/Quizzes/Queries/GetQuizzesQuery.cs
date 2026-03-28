using Application.Contracts.Modules.Quizzes.Dtos;
using LP.Common.Application.Contracts.CQRS;
using LP.Common.Application.Contracts.ReadModel;

namespace Application.Contracts.Modules.Quizzes.Queries;

public record GetQuizzesQuery(PaginationData Pagination) : IQuery<PaginatedListDto<QuizzesListItemDto>>;