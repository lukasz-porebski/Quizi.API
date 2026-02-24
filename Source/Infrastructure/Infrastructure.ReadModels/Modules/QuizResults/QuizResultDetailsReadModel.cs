using Application.Contracts.Modules.QuizResults.Dtos;
using Application.Contracts.Modules.QuizResults.Interfaces;
using Application.Contracts.Modules.QuizResults.Queries;
using Common.Domain.ValueObjects;
using Common.Infrastructure.ReadModels.Dapper;
using Common.Infrastructure.ReadModels.Dapper.Data;

namespace Infrastructure.ReadModels.Modules.QuizResults;

public class QuizResultDetailsReadModel(IDatabaseConnectionStringProvider connectionStringProvider)
    : BaseReadModel(connectionStringProvider), IQuizResultDetailsReadModel
{
    public Task<QuizResultDetailsDto?> Get(
        GetQuizResultDetailsQuery query, AggregateId userId, CancellationToken cancellationToken)
    {
        var parameters = new GetByIdData(query.Id, userId);

        const string sqlQuery = @$"
SELECT
    Id AS {nameof(QuizResultDetailsDto.Id)},
    Title AS {nameof(QuizResultDetailsDto.Title)},
    QuizRunningPeriodStart AS {nameof(QuizResultDetailsDto.QuizRunningPeriodStart)},
    QuizRunningPeriodEnd AS {nameof(QuizResultDetailsDto.QuizRunningPeriodEnd)},
    MaxDuration AS {nameof(QuizResultDetailsDto.MaxDuration)},
    NegativePoints AS {nameof(QuizResultDetailsDto.NegativePoints)},
    RandomQuestions AS {nameof(QuizResultDetailsDto.RandomQuestions)},
    RandomAnswers AS {nameof(QuizResultDetailsDto.RandomAnswers)}
FROM QuizResults
WHERE Id = @{nameof(parameters.Id)} 
    AND UserId = @{nameof(parameters.UserId)};

SELECT
    No AS {nameof(QuizResultDetailsOpenQuestionDto.No)},
    OrdinalNumber AS {nameof(QuizResultDetailsOpenQuestionDto.OrdinalNumber)},
    Text AS {nameof(QuizResultDetailsOpenQuestionDto.Text)},
    CorrectAnswer AS {nameof(QuizResultDetailsOpenQuestionDto.CorrectAnswer)},
    GivenAnswer AS {nameof(QuizResultDetailsOpenQuestionDto.GivenAnswer)},
    ScoredPoints AS {nameof(QuizResultDetailsOpenQuestionDto.ScoredPoints)},
    PointsPossibleToGet AS {nameof(QuizResultDetailsOpenQuestionDto.PointsPossibleToGet)},
    IsCorrect AS {nameof(QuizResultDetailsOpenQuestionDto.IsCorrect)}
FROM QuizResultOpenQuestions
WHERE Id = @{nameof(parameters.Id)};

SELECT
    No AS {nameof(QuizResultDetailsClosedQuestionDto.No)},
    OrdinalNumber AS {nameof(QuizResultDetailsClosedQuestionDto.OrdinalNumber)},
    Text AS {nameof(QuizResultDetailsClosedQuestionDto.Text)},
    ScoredPoints AS {nameof(QuizResultDetailsClosedQuestionDto.ScoredPoints)},
    PointsPossibleToGet AS {nameof(QuizResultDetailsClosedQuestionDto.PointsPossibleToGet)}
FROM QuizResultSingleChoiceQuestions
WHERE Id = @{nameof(parameters.Id)};

SELECT
    No AS {nameof(QuizResultDetailsClosedQuestionAnswerDto.No)},
    OrdinalNumber AS {nameof(QuizResultDetailsClosedQuestionAnswerDto.OrdinalNumber)},
    Text AS {nameof(QuizResultDetailsClosedQuestionAnswerDto.Text)},
    IsCorrect AS {nameof(QuizResultDetailsClosedQuestionAnswerDto.IsCorrect)},
    IsSelected AS {nameof(QuizResultDetailsClosedQuestionAnswerDto.IsSelected)}
FROM QuizResultSingleChoiceQuestionAnswers
WHERE Id = @{nameof(parameters.Id)};

SELECT
    No AS {nameof(QuizResultDetailsClosedQuestionDto.No)},
    OrdinalNumber AS {nameof(QuizResultDetailsClosedQuestionDto.OrdinalNumber)},
    Text AS {nameof(QuizResultDetailsClosedQuestionDto.Text)},
    ScoredPoints AS {nameof(QuizResultDetailsClosedQuestionDto.ScoredPoints)},
    PointsPossibleToGet AS {nameof(QuizResultDetailsClosedQuestionDto.PointsPossibleToGet)}
FROM QuizResultMultipleChoiceQuestions
WHERE Id = @{nameof(parameters.Id)};

SELECT
    No AS {nameof(QuizResultDetailsClosedQuestionAnswerDto.No)},
    OrdinalNumber AS {nameof(QuizResultDetailsClosedQuestionAnswerDto.OrdinalNumber)},
    Text AS {nameof(QuizResultDetailsClosedQuestionAnswerDto.Text)},
    IsCorrect AS {nameof(QuizResultDetailsClosedQuestionAnswerDto.IsCorrect)},
    IsSelected AS {nameof(QuizResultDetailsClosedQuestionAnswerDto.IsSelected)}
FROM QuizResultMultipleChoiceQuestionAnswers
WHERE Id = @{nameof(parameters.Id)};
";

        return GetDetailsWithElements<QuizResultDetailsDto>(
            sqlQuery,
            setDetails: async (reader, dto) =>
            {
                var openQuestionsTask = await reader.ReadAsync<QuizResultDetailsOpenQuestionDto>();
                var singleChoiceQuestionsTask = await reader.ReadAsync<QuizResultDetailsClosedQuestionDto>();
                var singleChoiceQuestionAnswersTask = await reader.ReadAsync<QuizResultDetailsClosedQuestionAnswerDto>();
                var multipleChoiceQuestionsTask = await reader.ReadAsync<QuizResultDetailsClosedQuestionDto>();
                var multipleChoiceQuestionAnswersTask = await reader.ReadAsync<QuizResultDetailsClosedQuestionAnswerDto>();

                dto.OpenQuestions = openQuestionsTask.ToArray();
                dto.SingleChoiceQuestions = singleChoiceQuestionsTask.ToArray();
                dto.MultipleChoiceQuestions = multipleChoiceQuestionsTask.ToArray();

                var singleChoiceQuestionAnswers = singleChoiceQuestionAnswersTask.ToLookup(k => k.No);
                foreach (var question in dto.SingleChoiceQuestions)
                {
                    question.Answers = singleChoiceQuestionAnswers[question.No]
                        .OrderBy(a => a.OrdinalNumber)
                        .ToArray();
                }

                var multipleChoiceQuestionAnswers = multipleChoiceQuestionAnswersTask.ToLookup(k => k.No);
                foreach (var question in dto.MultipleChoiceQuestions)
                {
                    question.Answers = multipleChoiceQuestionAnswers[question.No]
                        .OrderBy(a => a.OrdinalNumber)
                        .ToArray();
                }
            },
            cancellationToken,
            parameters
        );
    }
}