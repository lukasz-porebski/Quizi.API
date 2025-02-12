using Application.Contracts.Modules.Quizzes.Commands;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models;

namespace Application.Modules.Quizzes.Extensions;

internal static class CreateQuizCommandExtensions
{
    public static QuizCreateData ToData(this CreateQuizCommand source, AggregateId ownerId) =>
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