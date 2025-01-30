using Common.Domain.Extensions;
using Domain.Modules.Quizzes.Data.Questions.Create;
using Domain.Modules.Quizzes.Models;

namespace Domain.Modules.Quizzes.Helpers;

internal static class QuizNewQuestionsAdder
{
    internal static List<OpenEndedQuestionEntity> AddNewQuestions(
        this IReadOnlyList<OpenEndedQuestionEntity> oldOpenEndedQuestions,
        List<QuizOpenEndedQuestionCreateData> newOpenEndedQuestions)
    {
        var nextEntityNo = oldOpenEndedQuestions.NextNo();
        var nextOrderNumber = oldOpenEndedQuestions.Max(q => q.OrderNumber) + 1;

        var result = oldOpenEndedQuestions.Concat(
            newOpenEndedQuestions.Select(q => new OpenEndedQuestionEntity(
                    no: nextEntityNo++,
                    createData: new QuizOpenEndedQuestionCreateData(
                        orderNumber: nextOrderNumber++,
                        text: q.Text,
                        correctAnswer: q.CorrectAnswer)
                )
            )
        );

        return result.ToList();
    }

    internal static List<SingleChoiceQuestionEntity> AddNewQuestions(
        this IReadOnlyList<SingleChoiceQuestionEntity> oldSingleChoiceQuestions,
        List<QuizSingleChoiceQuestionCreateData> newSingleChoiceQuestions)
    {
        var nextEntityNo = oldSingleChoiceQuestions.NextNo();
        var nextOrderNumber = oldSingleChoiceQuestions.Max(q => q.OrderNumber) + 1;

        var result = oldSingleChoiceQuestions.Concat(
            newSingleChoiceQuestions.Select(q => new SingleChoiceQuestionEntity(
                    no: nextEntityNo++,
                    createData: new QuizSingleChoiceQuestionCreateData(
                        orderNumber: nextOrderNumber++,
                        text: q.Text,
                        correctAnswer: q.CorrectAnswer,
                        wrongAnswers: q.WrongAnswers)
                )
            )
        );

        return result.ToList();
    }

    internal static List<MultipleChoiceQuestionEntity> AddNewQuestions(
        this IReadOnlyList<MultipleChoiceQuestionEntity> oldMultipleChoiceQuestions,
        List<QuizMultipleChoiceQuestionCreateData> newMultipleChoiceQuestions)
    {
        var nextEntityNo = oldMultipleChoiceQuestions.NextNo();
        var nextOrderNumber = oldMultipleChoiceQuestions.Max(q => q.OrderNumber) + 1;

        var result = oldMultipleChoiceQuestions.Concat(
            newMultipleChoiceQuestions.Select(q => new MultipleChoiceQuestionEntity(
                    no: nextEntityNo++,
                    createData: new QuizMultipleChoiceQuestionCreateData(
                        orderNumber: nextOrderNumber++,
                        text: q.Text,
                        correctAnswers: q.CorrectAnswers,
                        wrongAnswers: q.WrongAnswers)
                )
            )
        );

        return result.ToList();
    }
}