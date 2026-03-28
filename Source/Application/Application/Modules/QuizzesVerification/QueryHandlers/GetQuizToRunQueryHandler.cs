using Application.Contracts.Modules.Quizzes.Enums;
using Application.Contracts.Modules.QuizzesVerification.Data;
using Application.Contracts.Modules.QuizzesVerification.Dtos;
using Application.Contracts.Modules.QuizzesVerification.Interfaces;
using Application.Contracts.Modules.QuizzesVerification.Queries;
using LP.Common.Application.Contracts.User;
using LP.Common.Application.CQRS;
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

        dto.Questions = dto.RandomQuestions
            ? Enumerable.Shuffle(dto.Questions).ToArray()
            : dto.Questions.OrderBy(q => q.OrdinalNumber).ToArray();

        var ordinalNumbersByQuestionKey = dto.Questions
            .Select((q, i) => new
            {
                q.No,
                q.Type,
                OrdinalNumber = i + 1
            })
            .ToDictionary(k => new QuestionKey(k.No, k.Type), v => v.OrdinalNumber);


        if (dto.RandomAnswers)
            dto.Questions.ForEach(q => q.Answers = Enumerable.Shuffle(q.Answers).ToArray());
        else
            dto.Questions.ForEach(q => q.Answers = q.Answers.OrderBy(a => a.OrdinalNumber).ToArray());

        return ToResponse(dto, ordinalNumbersByQuestionKey);
    }

    private static QuizToRunData ToResponse(
        QuizToRunDto dto, IReadOnlyDictionary<QuestionKey, int> ordinalNumbersByQuestionKey) =>
        new(dto.Id,
            dto.Title,
            dto.Duration,
            dto.Questions
                .Where(q => q.Type == QuizQuestionType.Open)
                .Select(q => ToOpenQuestionResponse(q, ordinalNumbersByQuestionKey[new QuestionKey(q.No, q.Type)]))
                .ToArray(),
            dto.Questions
                .Where(q => q.Type == QuizQuestionType.SingleChoice)
                .Select(q => ToClosedQuestionResponse(q, ordinalNumbersByQuestionKey[new QuestionKey(q.No, q.Type)]))
                .ToArray(),
            dto.Questions
                .Where(q => q.Type == QuizQuestionType.MultipleChoice)
                .Select(q => ToClosedQuestionResponse(q, ordinalNumbersByQuestionKey[new QuestionKey(q.No, q.Type)]))
                .ToArray());

    private static QuizToRunOpenQuestionData ToOpenQuestionResponse(QuizToRunQuestionDto dto, int ordinalNumber) =>
        new(dto.No, ordinalNumber, dto.Text);

    private static QuizToRunClosedQuestionData ToClosedQuestionResponse(QuizToRunQuestionDto dto, int ordinalNumber) =>
        new(dto.No,
            ordinalNumber,
            dto.Text,
            dto.Answers
                .Select((a, index) => new QuizToRunClosedQuestionAnswerData(a.SubNo, index + 1, a.Text))
                .OrderBy(a => a.OrdinalNumber)
                .ToArray());

    private sealed record QuestionKey(int No, QuizQuestionType Type);
}