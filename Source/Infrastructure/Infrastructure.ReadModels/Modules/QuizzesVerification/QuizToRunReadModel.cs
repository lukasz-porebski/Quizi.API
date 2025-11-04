using Application.Contracts.Modules.Quizzes.Enums;
using Application.Contracts.Modules.QuizzesVerification.Dtos;
using Application.Contracts.Modules.QuizzesVerification.Interfaces;
using Application.Contracts.Modules.QuizzesVerification.Queries;
using Common.Domain.ValueObjects;
using Common.Infrastructure.ReadModels.Dapper;

namespace Infrastructure.ReadModels.Modules.QuizzesVerification;

public class QuizToRunReadModel(IDatabaseConnectionStringProvider connectionStringProvider)
    : BaseReadModel(connectionStringProvider), IQuizToRunReadModel
{
    public Task<QuizToRunDto?> Get(GetQuizToRunQuery query, AggregateId userId, CancellationToken cancellationToken)
    {
        var parameters = new
        {
            Id = query.Id.ToString(),
            UserId = userId.ToString(),
            OpenQuestionType = (int)QuizQuestionType.Open,
            SingleChoiceQuestionType = (int)QuizQuestionType.SingleChoice,
            MultipleChoiceQuestionType = (int)QuizQuestionType.MultipleChoice
        };

        const string sqlQuery = @$"
SELECT
    Q.Id AS {nameof(QuizToRunDto.Id)},
    Q.Title AS {nameof(QuizToRunDto.Title)},
    Q.Duration AS {nameof(QuizToRunDto.Duration)},
	Q.RandomQuestions AS {nameof(QuizToRunDto.RandomQuestions)},
	Q.RandomAnswers AS {nameof(QuizToRunDto.RandomAnswers)}
FROM Quizzes Q
WHERE Id = @{nameof(parameters.Id)}
    AND (OwnerId = @{nameof(parameters.UserId)}
         OR EXISTS(SELECT *
                   FROM SharedQuizzes SQ
                   JOIN SharedQuizUsers SQU ON SQU.Id = SQ.Id
                   WHERE SQ.QuizId = Q.Id 
                      AND SQU.UserId = @{nameof(parameters.UserId)}));

WITH Questions AS (
	SELECT 
		Id, No, OrdinalNumber, Text, @{nameof(parameters.OpenQuestionType)} AS Type
	FROM QuizOpenQuestions
	UNION
	SELECT 
		Id, No, OrdinalNumber, Text, @{nameof(parameters.SingleChoiceQuestionType)} AS Type
	FROM QuizSingleChoiceQuestions
	UNION
	SELECT 
		Id, No, OrdinalNumber, Text, @{nameof(parameters.MultipleChoiceQuestionType)} AS Type
	FROM QuizMultipleChoiceQuestions
)
	
SELECT *
INTO TEMP RandomlySelectedQuestions
FROM Questions
WHERE Id = @{nameof(parameters.Id)}
ORDER BY RANDOM()
LIMIT (SELECT QuestionsCountInRunningQuiz FROM Quizzes WHERE Id = @{nameof(parameters.Id)});

SELECT 
    Q.No AS {nameof(QuizToRunQuestionDto.No)},
    Q.OrdinalNumber AS {nameof(QuizToRunQuestionDto.OrdinalNumber)},
    Q.Text AS {nameof(QuizToRunQuestionDto.Text)},
    Q.Type AS {nameof(QuizToRunQuestionDto.Type)}
FROM RandomlySelectedQuestions Q;
	
WITH QuestionAnswers AS (
	SELECT 
		Id, No, No AS SubNo, OrdinalNumber, Text, @{nameof(parameters.OpenQuestionType)} AS Type
	FROM QuizOpenQuestions
	UNION
	SELECT 
		Id, No, SubNo, OrdinalNumber, Text, @{nameof(parameters.SingleChoiceQuestionType)} AS Type
	FROM QuizSingleChoiceQuestionAnswers
	UNION
	SELECT 
		Id, No, SubNo, OrdinalNumber, Text, @{nameof(parameters.MultipleChoiceQuestionType)} AS Type
	FROM QuizMultipleChoiceQuestionAnswers
)

SELECT 
    QA.No AS {nameof(QuizToRunQuestionAnswerDto.No)},
    QA.SubNo AS {nameof(QuizToRunQuestionAnswerDto.SubNo)},
    QA.OrdinalNumber AS {nameof(QuizToRunQuestionAnswerDto.OrdinalNumber)},
    QA.Text AS {nameof(QuizToRunQuestionAnswerDto.Text)},
    QA.Type AS {nameof(QuizToRunQuestionAnswerDto.Type)}
FROM QuestionAnswers QA
JOIN RandomlySelectedQuestions Q ON Q.Id = QA.Id AND Q.No= QA.No AND Q.Type= QA.Type;
";

        return GetDetailsWithElements<QuizToRunDto>(
            sqlQuery,
            setDetails: async (reader, dto) =>
            {
                var questionsTask = reader.ReadAsync<QuizToRunQuestionDto>();
                var questionAnswersTask = reader.ReadAsync<QuizToRunQuestionAnswerDto>();

                await Task.WhenAll(questionsTask, questionAnswersTask);

                dto.Questions = questionsTask.Result.ToArray();

                var questionAnswers = questionAnswersTask.Result.ToLookup(k => new AnswerKey(k.No, k.Type));
                foreach (var question in dto.Questions)
                    question.Answers = questionAnswers[new AnswerKey(question.No, question.Type)].ToArray();
            },
            cancellationToken,
            parameters
        );
    }

    private record AnswerKey(int No, QuizQuestionType Type);
}