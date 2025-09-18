using Application.Contracts.Modules.Quizzes.Dtos;
using Application.Contracts.Modules.Quizzes.Enums;
using Application.Contracts.Modules.QuizzesVerification.Interfaces;
using Application.Contracts.Modules.QuizzesVerification.Queries;
using Common.Infrastructure.ReadModels.Dapper;

namespace Infrastructure.ReadModels.Modules.Quizzes;

public class QuizToRunReadModel(IDatabaseConnectionStringProvider connectionStringProvider)
    : BaseReadModel(connectionStringProvider), IQuizToRunReadModel
{
    public Task<QuizToRunDto> Get(GetQuizToRunQuery query, CancellationToken cancellationToken)
    {
        var parameters = new
        {
            Id = query.Id.ToString(),
            OpenQuestionType = (int)QuizQuestionType.Open,
            SingleChoiceQuestionType = (int)QuizQuestionType.SingleChoice,
            MultipleChoiceQuestionType = (int)QuizQuestionType.MultipleChoice
        };

        const string sqlQuery = @$"
SELECT
    Id AS {nameof(QuizToRunDto.Id)},
    Title AS {nameof(QuizToRunDto.Title)},
    Duration AS {nameof(QuizToRunDto.Duration)},
	RandomQuestions AS {nameof(QuizToRunDto.RandomQuestions)},
	RandomAnswers AS {nameof(QuizToRunDto.RandomAnswers)}
FROM Quizzes
WHERE Id = @{nameof(parameters.Id)};

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

SELECT TOP (SELECT QuestionsCountInRunningQuiz FROM Quizzes WHERE Id = @{nameof(parameters.Id)}) *
INTO #RandomlySelectedQuestions
FROM Questions
WHERE Id = @{nameof(parameters.Id)}
ORDER BY NEWID();

SELECT 
    Q.No AS {nameof(QuizToRunQuestionDto.No)},
    Q.OrdinalNumber AS {nameof(QuizToRunQuestionDto.OrdinalNumber)},
    Q.Text AS {nameof(QuizToRunQuestionDto.Text)},
    Q.Type AS {nameof(QuizToRunQuestionDto.Type)}
FROM #RandomlySelectedQuestions Q;
	
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
JOIN #RandomlySelectedQuestions Q ON Q.Id = QA.Id AND Q.No= QA.No AND Q.Type= QA.Type;
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