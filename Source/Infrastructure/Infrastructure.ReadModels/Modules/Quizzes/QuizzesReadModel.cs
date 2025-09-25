using Application.Contracts.Modules.Quizzes.Dtos;
using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Contracts.Modules.Quizzes.Queries;
using Common.Application.Contracts.ReadModel;
using Common.Domain.ValueObjects;
using Common.Infrastructure.ReadModels.Dapper;
using Dapper;

namespace Infrastructure.ReadModels.Modules.Quizzes;

public class QuizzesReadModel(IDatabaseConnectionStringProvider connectionStringProvider)
    : BaseReadModel(connectionStringProvider), IQuizzesReadModel
{
    public Task<PaginatedListDto<QuizzesListItemDto>> Get(
        GetQuizzesQuery query, AggregateId userId, CancellationToken cancellationToken)
    {
        var parameters = new
        {
            UserId = userId.ToString()
        };

        const string sqlQuery = @$"
SELECT
    Q.Id AS {nameof(QuizzesListItemDto.Id)},
    Q.Title AS {nameof(QuizzesListItemDto.Title)},
    Q.Duration AS {nameof(QuizzesListItemDto.Duration)},
    Q.CopyMode AS {nameof(QuizzesListItemDto.CopyMode)},
    (SELECT COUNT(Id) FROM QuizOpenQuestions QO WHERE QO.Id = Q.Id) +
        (SELECT COUNT(Id) FROM QuizSingleChoiceQuestions QS WHERE QS.Id = Q.Id) +
        (SELECT COUNT(Id) FROM QuizMultipleChoiceQuestions QM WHERE QM.Id = Q.Id) AS {nameof(QuizzesListItemDto.QuestionsCount)},
    Q.QuestionsCountInRunningQuiz AS {nameof(QuizzesListItemDto.QuestionsCountInRunningQuiz)},
    Q.CreatedAt AS {nameof(QuizzesListItemDto.CreatedAt)}
FROM Quizzes Q
    WHERE (OwnerId = @{nameof(parameters.UserId)}
           OR EXISTS(SELECT *
                     FROM SharedQuizzes SQ
                     JOIN SharedQuizUsers SQU ON SQU.Id = SQ.Id
                     WHERE SQ.QuizId = Q.Id 
                        AND SQU.UserId = @{nameof(parameters.UserId)}))
";

        return GetPaginatedList<QuizzesListItemDto>(
            query.Pagination,
            sqlQuery,
            orderByQuery: $"{nameof(QuizzesListItemDto.CreatedAt)} DESC",
            readItems: async reader => (await reader.ReadAsync<QuizzesListItemDto>()).ToArray(),
            cancellationToken,
            searchColumns: [nameof(QuizzesListItemDto.Title)],
            parameters: new DynamicParameters(parameters)
        );
    }
}