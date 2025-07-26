using Application.Contracts.Modules.Quizzes.Dtos;
using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Contracts.Modules.Quizzes.Queries;
using Common.Application.Contracts.ReadModel;
using Common.Infrastructure.ReadModels.Dapper;

namespace Infrastructure.ReadModels.Modules.Quizzes;

public class QuizzesReadModel(IDatabaseConnectionStringProvider connectionStringProvider)
    : BaseReadModel(connectionStringProvider), IQuizzesReadModel
{
    public Task<PaginatedListDto<QuizzesListItemDto>> Get(GetQuizzesQuery query, CancellationToken cancellationToken)
    {
        var sqlQuery = @"
SELECT 
    Id 
FROM Quizzes
";

        return GetPaginatedList<QuizzesListItemDto>(
            query.Pagination,
            sqlQuery,
            orderByQuery: nameof(QuizzesListItemDto.Id),
            readItems: async reader => (await reader.ReadAsync<QuizzesListItemDto>()).ToArray(),
            cancellationToken
        );
    }
}