using Application.Contracts.Modules.Quizzes.Enums;
using Application.Contracts.Modules.QuizzesVerification.Data;
using Application.Contracts.Modules.QuizzesVerification.Dtos;
using Application.Contracts.Modules.QuizzesVerification.Interfaces;
using Application.Contracts.Modules.QuizzesVerification.Queries;
using Common.Application.Contracts.User;
using Common.Application.CQRS;
using MoreLinq.Extensions;

namespace Application.Modules.QuizzesVerification.QueryHandlers;

public class GetQuizToRunQueryHandler(IQuizToRunReadModel readModel, IUserContextProvider userContextProvider)
    : IQueryHandler<GetQuizToRunQuery, QuizToRunData?>
{
    public async Task<QuizToRunData?> Handle(GetQuizToRunQuery query, CancellationToken cancellationToken)
    {
        var dto = await readModel.Get(query, userContextProvider.GetOrThrow().UserId, cancellationToken);
        if (dto is null)
            return null;

        if (dto.RandomQuestions)
            dto.Questions = Enumerable.Shuffle(dto.Questions).ToArray();

        if (dto.RandomAnswers)
            dto.Questions.ForEach(q => q.Answers = Enumerable.Shuffle(q.Answers).ToArray());

        return ToResponse(dto);
    }

    private static QuizToRunData ToResponse(QuizToRunDto dto) =>
        new(dto.Id,
            dto.Title,
            dto.Duration,
            dto.Questions
                .Where(q => q.Type == QuizQuestionType.Open)
                .Select(ToOpenQuestionResponse)
                .ToArray(),
            dto.Questions
                .Where(q => q.Type == QuizQuestionType.SingleChoice)
                .Select(ToClosedQuestionResponse)
                .ToArray(),
            dto.Questions
                .Where(q => q.Type == QuizQuestionType.MultipleChoice)
                .Select(ToClosedQuestionResponse)
                .ToArray());

    private static QuizToRunOpenQuestionData ToOpenQuestionResponse(QuizToRunQuestionDto dto) =>
        new(dto.No, dto.OrdinalNumber, dto.Text);

    private static QuizToRunClosedQuestionData ToClosedQuestionResponse(QuizToRunQuestionDto dto) =>
        new(dto.No,
            dto.OrdinalNumber,
            dto.Text,
            dto.Answers
                .Select(a => new QuizToRunClosedQuestionAnswerData(a.No, a.OrdinalNumber, a.Text))
                .ToArray());
}