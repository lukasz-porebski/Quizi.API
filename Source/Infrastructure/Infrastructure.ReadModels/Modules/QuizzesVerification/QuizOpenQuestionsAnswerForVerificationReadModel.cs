using Application.Contracts.Modules.QuizzesVerification.Interfaces;
using Application.Contracts.Modules.QuizzesVerification.Queries;
using Common.Domain.ValueObjects;
using Common.Infrastructure.ReadModels.Dapper;
using Common.Infrastructure.ReadModels.Dapper.Data;
using PublishedLanguage.Modules.QuizzesVerification.Responses;

namespace Infrastructure.ReadModels.Modules.QuizzesVerification;

public class QuizOpenQuestionsAnswerForVerificationReadModel(IDatabaseConnectionStringProvider connectionStringProvider)
    : BaseReadModel(connectionStringProvider), IQuizOpenQuestionsAnswerForVerificationReadModel
{
    public Task<IReadOnlyCollection<QuizOpenQuestionAnswerForVerificationResponse>> Get(
        GetQuizOpenQuestionsAnswerForVerificationQuery query, AggregateId userId, CancellationToken cancellationToken)
    {
        var parameters = new GetByIdData(query.Id, userId);

        const string sqlQuery = @$"
SELECT
    O.No AS {nameof(QuizOpenQuestionAnswerForVerificationResponse.No)},
    O.Answer AS {nameof(QuizOpenQuestionAnswerForVerificationResponse.Text)}
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

        return GetList<QuizOpenQuestionAnswerForVerificationResponse>(sqlQuery, cancellationToken, parameters);
    }
}