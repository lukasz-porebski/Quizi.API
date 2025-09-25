using Application.Contracts.Modules.QuizResults.Dtos;
using Application.Contracts.Modules.QuizResults.Interfaces;
using Application.Contracts.Modules.QuizResults.Queries;
using Common.Application.Contracts.ReadModel;
using Common.Infrastructure.ReadModels.Dapper;
using Common.Infrastructure.ReadModels.Dapper.Utils;

namespace Infrastructure.ReadModels.Modules.QuizResults;

public class QuizResultsReadModel(IDatabaseConnectionStringProvider connectionStringProvider)
    : BaseReadModel(connectionStringProvider), IQuizResultsReadModel
{
    public Task<PaginatedListDto<QuizResultsListItemDto>> Get(GetQuizResultsQuery query, CancellationToken cancellationToken)
    {
        var sqlQuery = @$"
SELECT
    R.Id AS {nameof(QuizResultsListItemDto.Id)},
    R.Title AS {nameof(QuizResultsListItemDto.Title)},
    (SELECT SUM(OQ.ScoredPoints) FROM QuizResultOpenQuestions OQ WHERE OQ.Id = R.Id)
    + (SELECT SUM(SQ.ScoredPoints) FROM QuizResultSingleChoiceQuestions SQ WHERE SQ.Id = R.Id)
    + (SELECT SUM(MQ.ScoredPoints) FROM QuizResultMultipleChoiceQuestions MQ WHERE MQ.Id = R.Id) 
        AS {nameof(QuizResultsListItemDto.ScoredPoints)},
    (SELECT SUM(OQ.PointsPossibleToGet) FROM QuizResultOpenQuestions OQ WHERE OQ.Id = R.Id)
    + (SELECT SUM(SQ.PointsPossibleToGet) FROM QuizResultSingleChoiceQuestions SQ WHERE SQ.Id = R.Id)
    + (SELECT SUM(MQ.PointsPossibleToGet) FROM QuizResultMultipleChoiceQuestions MQ WHERE MQ.Id = R.Id) 
        AS {nameof(QuizResultsListItemDto.PointsPossibleToGet)},
    R.QuizRunningPeriodStart AS {nameof(QuizResultsListItemDto.QuizRunningPeriodStart)},
    R.QuizRunningPeriodEnd AS {nameof(QuizResultsListItemDto.QuizRunningPeriodEnd)},
    {SqlUtils.GetTimeSpan("R.QuizRunningPeriodStart", "R.QuizRunningPeriodEnd")} AS {nameof(QuizResultsListItemDto.Duration)},
    R.MaxDuration AS {nameof(QuizResultsListItemDto.MaxDuration)},
    R.CreatedAt AS {nameof(QuizResultsListItemDto.CreatedAt)}
FROM QuizResults R
";

        return GetPaginatedList<QuizResultsListItemDto>(
            query.Pagination,
            sqlQuery,
            orderByQuery: $"{nameof(QuizResultsListItemDto.CreatedAt)} DESC",
            readItems: async reader => (await reader.ReadAsync<QuizResultsListItemDto>()).ToArray(),
            cancellationToken,
            searchColumns: [nameof(QuizResultsListItemDto.Title)]
        );
    }
}