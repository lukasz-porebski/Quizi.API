using Application.Contracts.Modules.QuizzesVerification.Interfaces;
using Application.Contracts.Modules.QuizzesVerification.Queries;
using Common.Infrastructure.ReadModels.Dapper;
using Common.Infrastructure.ReadModels.Dapper.Data;
using PublishedLanguage.Modules.QuizzesVerification.Responses;

namespace Infrastructure.ReadModels.Modules.QuizzesVerification;

public class QuizOpenQuestionsAnswerForVerificationReadModel(IDatabaseConnectionStringProvider connectionStringProvider)
    : BaseReadModel(connectionStringProvider), IQuizOpenQuestionsAnswerForVerificationReadModel
{
    public Task<IReadOnlyCollection<QuizOpenQuestionAnswerForVerificationResponse>> Get(
        GetQuizOpenQuestionsAnswerForVerificationQuery query, CancellationToken cancellationToken)
    {
        var parameters = new GetByIdData(query.Id);

        const string sqlQuery = @$"
SELECT
    No AS {nameof(QuizOpenQuestionAnswerForVerificationResponse.No)},
    Answer AS {nameof(QuizOpenQuestionAnswerForVerificationResponse.Answer)}
FROM QuizOpenQuestions
WHERE Id = @{nameof(parameters.Id)};
";

        return GetList<QuizOpenQuestionAnswerForVerificationResponse>(sqlQuery, cancellationToken, parameters);
    }
}