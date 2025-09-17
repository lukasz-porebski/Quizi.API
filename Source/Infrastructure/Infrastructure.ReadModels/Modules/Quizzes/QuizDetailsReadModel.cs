using Application.Contracts.Modules.Quizzes.Dtos;
using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Contracts.Modules.Quizzes.Queries;
using Common.Infrastructure.ReadModels.Dapper;
using Common.Infrastructure.ReadModels.Dapper.Data;

namespace Infrastructure.ReadModels.Modules.Quizzes;

public class QuizDetailsReadModel(IDatabaseConnectionStringProvider connectionStringProvider)
    : BaseReadModel(connectionStringProvider), IQuizDetailsReadModel
{
    public Task<QuizDetailsDto> Get(GetQuizDetailsQuery query, CancellationToken cancellationToken)
    {
        var parameters = new GetByIdData(query.Id);

        const string sqlQuery = @$"
SELECT
    Id AS {nameof(QuizDetailsDto.Id)},
    Title AS {nameof(QuizDetailsDto.Title)},
    Description AS {nameof(QuizDetailsDto.Description)},
    Duration AS {nameof(QuizDetailsDto.Duration)},
    QuestionsCountInRunningQuiz AS {nameof(QuizDetailsDto.QuestionsCountInRunningQuiz)},
    RandomQuestions AS {nameof(QuizDetailsDto.RandomQuestions)},
    RandomAnswers AS {nameof(QuizDetailsDto.RandomAnswers)},
    NegativePoints AS {nameof(QuizDetailsDto.NegativePoints)},
    CopyMode AS {nameof(QuizDetailsDto.CopyMode)},
    CopyMode AS {nameof(QuizDetailsDto.CopyMode)}
FROM Quizzes
WHERE Id = @{nameof(parameters.Id)};

SELECT
    No AS {nameof(QuizDetailsOpenQuestionDto.No)},
    OrdinalNumber AS {nameof(QuizDetailsOpenQuestionDto.OrdinalNumber)},
    Text AS {nameof(QuizDetailsOpenQuestionDto.Text)},
    Answer AS {nameof(QuizDetailsOpenQuestionDto.Answer)}
FROM QuizOpenQuestions
WHERE Id = @{nameof(parameters.Id)};

SELECT
    No AS {nameof(QuizDetailsClosedQuestionDto.No)},
    OrdinalNumber AS {nameof(QuizDetailsClosedQuestionDto.OrdinalNumber)},
    Text AS {nameof(QuizDetailsClosedQuestionDto.Text)}
FROM QuizSingleChoiceQuestions
WHERE Id = @{nameof(parameters.Id)};

SELECT
    No AS {nameof(QuizDetailsClosedQuestionAnswerDto.No)},
    SubNo AS {nameof(QuizDetailsClosedQuestionAnswerDto.SubNo)},
    OrdinalNumber AS {nameof(QuizDetailsClosedQuestionAnswerDto.OrdinalNumber)},
    Text AS {nameof(QuizDetailsClosedQuestionAnswerDto.Text)},
    IsCorrect AS {nameof(QuizDetailsClosedQuestionAnswerDto.IsCorrect)}
FROM QuizSingleChoiceQuestionAnswers
WHERE Id = @{nameof(parameters.Id)};

SELECT
    No AS {nameof(QuizDetailsClosedQuestionDto.No)},
    OrdinalNumber AS {nameof(QuizDetailsClosedQuestionDto.OrdinalNumber)},
    Text AS {nameof(QuizDetailsClosedQuestionDto.Text)}
FROM QuizMultipleChoiceQuestions
WHERE Id = @{nameof(parameters.Id)};

SELECT
    No AS {nameof(QuizDetailsClosedQuestionAnswerDto.No)},
    SubNo AS {nameof(QuizDetailsClosedQuestionAnswerDto.SubNo)},
    OrdinalNumber AS {nameof(QuizDetailsClosedQuestionAnswerDto.OrdinalNumber)},
    Text AS {nameof(QuizDetailsClosedQuestionAnswerDto.Text)},
    IsCorrect AS {nameof(QuizDetailsClosedQuestionAnswerDto.IsCorrect)}
FROM QuizMultipleChoiceQuestionAnswers
WHERE Id = @{nameof(parameters.Id)};
";

        return GetDetailsWithElements<QuizDetailsDto>(
            sqlQuery,
            setDetails: async (reader, dto) =>
            {
                var openQuestionsTask = reader.ReadAsync<QuizDetailsOpenQuestionDto>();
                var singleChoiceQuestionsTask = reader.ReadAsync<QuizDetailsClosedQuestionDto>();
                var singleChoiceQuestionAnswersTask = reader.ReadAsync<QuizDetailsClosedQuestionAnswerDto>();
                var multipleChoiceQuestionsTask = reader.ReadAsync<QuizDetailsClosedQuestionDto>();
                var multipleChoiceQuestionAnswersTask = reader.ReadAsync<QuizDetailsClosedQuestionAnswerDto>();

                await Task.WhenAll(
                    openQuestionsTask,
                    singleChoiceQuestionsTask,
                    singleChoiceQuestionAnswersTask,
                    multipleChoiceQuestionsTask,
                    multipleChoiceQuestionAnswersTask
                );

                dto.OpenQuestions = openQuestionsTask.Result.ToArray();
                dto.SingleChoiceQuestions = singleChoiceQuestionsTask.Result.ToArray();
                dto.MultipleChoiceQuestions = multipleChoiceQuestionsTask.Result.ToArray();

                var singleChoiceQuestionAnswers = singleChoiceQuestionAnswersTask.Result.ToLookup(k => k.No);
                foreach (var question in dto.SingleChoiceQuestions)
                    question.Answers = singleChoiceQuestionAnswers[question.No].ToArray();

                var multipleChoiceQuestionAnswers = multipleChoiceQuestionAnswersTask.Result.ToLookup(k => k.No);
                foreach (var question in dto.MultipleChoiceQuestions)
                    question.Answers = multipleChoiceQuestionAnswers[question.No].ToArray();
            },
            cancellationToken,
            parameters
        );
    }
}