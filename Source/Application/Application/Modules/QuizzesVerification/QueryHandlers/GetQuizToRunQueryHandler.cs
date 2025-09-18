using Application.Contracts.Modules.Quizzes.Dtos;
using Application.Contracts.Modules.Quizzes.Enums;
using Application.Contracts.Modules.QuizzesVerification.Interfaces;
using Application.Contracts.Modules.QuizzesVerification.Queries;
using Common.Application.CQRS;
using MoreLinq;
using PublishedLanguage.Modules.QuizzesVerification.Responses;

namespace Application.Modules.QuizzesVerification.QueryHandlers;

public class GetQuizToRunQueryHandler(IQuizToRunReadModel readModel) : IQueryHandler<GetQuizToRunQuery, QuizToRunResponse>
{
    public async Task<QuizToRunResponse> Handle(GetQuizToRunQuery query, CancellationToken cancellationToken)
    {
        var dto = await readModel.Get(query, cancellationToken);

        if (dto.RandomQuestions)
            dto.Questions = dto.Questions.Shuffle().ToArray();

        if (dto.RandomAnswers)
            dto.Questions.ForEach(q => q.Answers = q.Answers.Shuffle().ToArray());

        return ToResponse(dto);
    }

    private static QuizToRunResponse ToResponse(QuizToRunDto dto) =>
        new()
        {
            Id = dto.Id,
            Title = dto.Title,
            Duration = dto.Duration,
            OpenQuestions = dto.Questions
                .Where(q => q.Type == QuizQuestionType.Open)
                .Select(ToOpenQuestionResponse)
                .ToArray(),
            SingleChoiceQuestions = dto.Questions
                .Where(q => q.Type == QuizQuestionType.SingleChoice)
                .Select(ToClosedQuestionResponse)
                .ToArray(),
            MultipleChoiceQuestions = dto.Questions
                .Where(q => q.Type == QuizQuestionType.MultipleChoice)
                .Select(ToClosedQuestionResponse)
                .ToArray()
        };

    private static QuizToRunOpenQuestionResponse ToOpenQuestionResponse(QuizToRunQuestionDto dto) =>
        new()
        {
            No = dto.No,
            OrdinalNumber = dto.OrdinalNumber,
            Text = dto.Text
        };

    private static QuizToRunClosedQuestionResponse ToClosedQuestionResponse(QuizToRunQuestionDto dto) =>
        new()
        {
            No = dto.No,
            OrdinalNumber = dto.OrdinalNumber,
            Text = dto.Text,
            Answers = dto.Answers
                .Select(a => new QuizToRunClosedQuestionAnswerResponse
                {
                    No = a.No,
                    OrdinalNumber = a.OrdinalNumber,
                    Text = a.Text
                })
                .ToArray()
        };
}