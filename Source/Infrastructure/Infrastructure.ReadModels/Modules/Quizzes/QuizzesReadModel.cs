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
        var sqlQuery = @$"
SELECT
    Q.Id AS {nameof(QuizzesListItemDto.Id)},
    Q.Title AS {nameof(QuizzesListItemDto.Title)},
    Q.Duration AS {nameof(QuizzesListItemDto.Duration)},
    Q.CopyMode AS {nameof(QuizzesListItemDto.CopyMode)},
    (SELECT COUNT(Id) FROM QuizOpenQuestions QO WHERE QO.Id = Q.Id) +
        (SELECT COUNT(Id) FROM QuizSingleChoiceQuestions QS WHERE QS.Id = Q.Id) +
        (SELECT COUNT(Id) FROM QuizMultipleChoiceQuestions QM WHERE QM.Id = Q.Id) AS {nameof(QuizzesListItemDto.QuestionsCount)},
    Q.QuestionsCountInRunningQuiz AS {nameof(QuizzesListItemDto.QuestionsCountInRunningQuiz)}
FROM Quizzes Q
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