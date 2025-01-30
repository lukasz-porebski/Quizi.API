using Common.Domain.Extensions;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Questions.Create;
using Domain.Modules.Quizzes.Models;

namespace Domain.Modules.Quizzes.Helpers;

internal static class QuizNewQuestionsAdder
{
    internal static List<OpenEndedQuestion> AddNewQuestions(
        this IReadOnlyCollection<OpenEndedQuestion> oldOpenEndedQuestions,
        AggregateId id,
        IReadOnlyCollection<QuizOpenEndedQuestionCreateData> newOpenEndedQuestions)
    {
        var nextEntityNo = oldOpenEndedQuestions.NextNo();
        var nextOrderNumber = oldOpenEndedQuestions.Max(q => q.OrderNumber) + 1;

        var result = oldOpenEndedQuestions.Concat(
            newOpenEndedQuestions.Select(q => new OpenEndedQuestion(
                    id,
                    no: nextEntityNo++,
                    new QuizOpenEndedQuestionCreateData(
                        OrderNumber: nextOrderNumber++,
                        q.Text,
                        q.CorrectAnswer)
                )
            )
        );

        return result.ToList();
    }

    internal static List<SingleChoiceQuestion> AddNewQuestions(
        this IReadOnlyCollection<SingleChoiceQuestion> oldSingleChoiceQuestions,
        AggregateId id,
        IReadOnlyCollection<QuizSingleChoiceQuestionCreateData> newSingleChoiceQuestions)
    {
        var nextEntityNo = oldSingleChoiceQuestions.NextNo();
        var nextOrderNumber = oldSingleChoiceQuestions.Max(q => q.OrderNumber) + 1;

        var result = oldSingleChoiceQuestions.Concat(
            newSingleChoiceQuestions.Select(q => new SingleChoiceQuestion(
                    id,
                    no: nextEntityNo++,
                    data: new QuizSingleChoiceQuestionCreateData(
                        OrderNumber: nextOrderNumber++,
                        q.Text,
                        q.CorrectAnswer,
                        q.WrongAnswers)
                )
            )
        );

        return result.ToList();
    }

    internal static List<MultipleChoiceQuestion> AddNewQuestions(
        this IReadOnlyCollection<MultipleChoiceQuestion> oldMultipleChoiceQuestions,
        AggregateId id,
        IReadOnlyCollection<QuizMultipleChoiceQuestionCreateData> newMultipleChoiceQuestions)
    {
        var nextEntityNo = oldMultipleChoiceQuestions.NextNo();
        var nextOrderNumber = oldMultipleChoiceQuestions.Max(q => q.OrderNumber) + 1;

        var result = oldMultipleChoiceQuestions.Concat(
            newMultipleChoiceQuestions.Select(q => new MultipleChoiceQuestion(
                    id,
                    no: nextEntityNo++,
                    new QuizMultipleChoiceQuestionCreateData(
                        OrderNumber: nextOrderNumber++,
                        q.Text,
                        q.CorrectAnswers,
                        q.WrongAnswers)
                )
            )
        );

        return result.ToList();
    }
}