using Common.Domain.Extensions;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models.Questions.Create;
using Domain.Modules.Quizzes.Models;

namespace Domain.Modules.Quizzes.Helpers;

internal static class QuizNewQuestionsAdder
{
    internal static List<QuizOpenQuestion> AddNewQuestions(
        this IReadOnlyCollection<QuizOpenQuestion> oldOpenQuestions,
        AggregateId id,
        IReadOnlyCollection<QuizOpenQuestionCreateData> newOpenQuestions)
    {
        var nextEntityNo = oldOpenQuestions.NextNo();
        var nextOrderNumber = oldOpenQuestions.Max(q => q.OrderNumber) + 1;

        var result = oldOpenQuestions.Concat(
            newOpenQuestions.Select(q => new QuizOpenQuestion(
                    id,
                    no: nextEntityNo++,
                    data: q with { OrderNumber = nextOrderNumber++ }
                )
            )
        );

        return result.ToList();
    }

    internal static List<QuizSingleChoiceQuestion> AddNewQuestions(
        this IReadOnlyCollection<QuizSingleChoiceQuestion> oldSingleChoiceQuestions,
        AggregateId id,
        IReadOnlyCollection<QuizSingleChoiceQuestionCreateData> newSingleChoiceQuestions)
    {
        var nextEntityNo = oldSingleChoiceQuestions.NextNo();
        var nextOrderNumber = oldSingleChoiceQuestions.Max(q => q.OrderNumber) + 1;

        var result = oldSingleChoiceQuestions.Concat(
            newSingleChoiceQuestions.Select(q => new QuizSingleChoiceQuestion(
                    id,
                    no: nextEntityNo++,
                    data: q with { OrderNumber = nextOrderNumber++ }
                )
            )
        );

        return result.ToList();
    }

    internal static List<QuizMultipleChoiceQuestion> AddNewQuestions(
        this IReadOnlyCollection<QuizMultipleChoiceQuestion> oldMultipleChoiceQuestions,
        AggregateId id,
        IReadOnlyCollection<QuizMultipleChoiceQuestionCreateData> newMultipleChoiceQuestions)
    {
        var nextEntityNo = oldMultipleChoiceQuestions.NextNo();
        var nextOrderNumber = oldMultipleChoiceQuestions.Max(q => q.OrderNumber) + 1;

        var result = oldMultipleChoiceQuestions.Concat(
            newMultipleChoiceQuestions.Select(q => new QuizMultipleChoiceQuestion(
                    id,
                    no: nextEntityNo++,
                    data: q with { OrderNumber = nextOrderNumber++ }
                )
            )
        );

        return result.ToList();
    }
}