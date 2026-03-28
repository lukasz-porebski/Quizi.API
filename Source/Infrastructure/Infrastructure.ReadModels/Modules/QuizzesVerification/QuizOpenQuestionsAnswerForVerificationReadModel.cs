using Application.Contracts.Modules.QuizzesVerification.Dtos;
using Application.Contracts.Modules.QuizzesVerification.Interfaces;
using Application.Contracts.Modules.QuizzesVerification.Queries;
using LP.Common.Domain.ValueObjects;
using LP.Common.Infrastructure.ReadModels.Dapper;
using LP.Common.Infrastructure.ReadModels.Dapper.Data;

namespace Infrastructure.ReadModels.Modules.QuizzesVerification;

public class QuizOpenQuestionsAnswerForVerificationReadModel(IDatabaseConnectionStringProvider connectionStringProvider)
    : BaseReadModel(connectionStringProvider), IQuizOpenQuestionsAnswerForVerificationReadModel
{
    public Task<IReadOnlyCollection<QuizOpenQuestionAnswerForVerificationDto>> Get(
        GetQuizOpenQuestionsAnswerForVerificationQuery query, AggregateId userId, CancellationToken cancellationToken)
    {
        var parameters = new GetByIdData(query.Id, userId);

        const string sqlQuery = @$"
SELECT
    O.No AS {nameof(QuizOpenQuestionAnswerForVerificationDto.No)},
    O.Answer AS {nameof(QuizOpenQuestionAnswerForVerificationDto.Text)}
FROM QuizOpenQuestions O
    JOIN Quizzes Q ON Q.Id = O.Id
WHERE O.Id = @{nameof(parameters.Id)}
    AND (OwnerId = @{nameof(parameters.UserId)}
         OR EXISTS(SELECT *
                   FROM SharedQuizzes SQ
                   JOIN SharedQuizUsers SQU ON SQU.Id = SQ.Id
                   WHERE SQ.QuizId = O.Id 
                      AND SQU.UserId = @{nameof(parameters.UserId)}));
";

        return GetList<QuizOpenQuestionAnswerForVerificationDto>(sqlQuery, cancellationToken, parameters);
    }
}