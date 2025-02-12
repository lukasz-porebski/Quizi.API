using Application.Contracts.Modules.Quizzes.Commands;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models;

namespace Application.Modules.Quizzes.Extensions;

internal static class UpdateQuizCommandExtensions
{
    public static QuizUpdateData ToData(this UpdateQuizCommand source, AggregateId ownerId) =>
        new(
            ownerId,
            source.Title,
            source.Description,
            source.Settings,
            source.OpenQuestions,
            source.SingleChoiceQuestions,
            source.MultipleChoiceQuestions
        );
}