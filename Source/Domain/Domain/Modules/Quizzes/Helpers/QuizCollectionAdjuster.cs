using Common.Domain.Extensions;
using Common.Domain.ValueObjects;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Data.Models.Questions.Create;
using Domain.Modules.Quizzes.Data.Models.Questions.Update;
using Domain.Modules.Quizzes.Models;
using MoreLinq;

namespace Domain.Modules.Quizzes.Helpers;

internal static class QuizCollectionAdjuster
{
    internal static List<QuizOpenQuestion> Adjust(
        this List<QuizOpenQuestion> current,
        AggregateId id,
        IReadOnlyCollection<QuizOpenQuestionUpdateData> target)
    {
        var nextNo = current.NextNo();

        var difference = current.GetDifferences(
            k => k.No, target.Where(t => t.EntityNo != null).ToArray(), k => k.EntityNo!);

        current.RemoveAll(entity => difference.ToRemove.Contains(entity));

        difference.Existing.ForEach(data => current.Find(c => c.No.Equals(data.Value.Target.EntityNo))!.Update(data.Value.Target));

        current.AddRange(target
            .Where(t => t.EntityNo == null)
            .Select(data => new QuizOpenQuestion(
                id, nextNo++, new QuizOpenQuestionCreateData(data.OrderNumber, data.Text, data.CorrectAnswer))));

        return current;
    }

    internal static List<QuizSingleChoiceQuestion> Adjust(
        this List<QuizSingleChoiceQuestion> current,
        AggregateId id,
        IReadOnlyCollection<QuizSingleChoiceQuestionUpdateData> target)
    {
        var nextNo = current.NextNo();

        var difference = current.GetDifferences(
            k => k.No, target.Where(t => t.EntityNo != null).ToArray(), k => k.EntityNo!);

        current.RemoveAll(entity => difference.ToRemove.Contains(entity));

        difference.Existing.ForEach(data => current.Find(c => c.No.Equals(data.Value.Target.EntityNo))!.Update(data.Value.Target));

        current.AddRange(target
            .Where(t => t.EntityNo == null)
            .Select(data =>
                new QuizSingleChoiceQuestion(
                    id,
                    nextNo++,
                    new QuizSingleChoiceQuestionCreateData(
                        data.OrderNumber,
                        data.Text,
                        data.Answers.Select(a => new QuizClosedQuestionAnswerCreateData(a.OrderNumber, a.Text, a.IsCorrect)).ToArray()
                    )
                )
            ));

        return current;
    }

    internal static List<QuizMultipleChoiceQuestion> Adjust(
        this List<QuizMultipleChoiceQuestion> current,
        AggregateId id,
        IReadOnlyCollection<QuizMultipleChoiceQuestionUpdateData> target)
    {
        var nextNo = current.NextNo();

        var difference = current.GetDifferences(
            k => k.No, target.Where(t => t.EntityNo != null).ToArray(), k => k.EntityNo!);

        current.RemoveAll(entity => difference.ToRemove.Contains(entity));

        difference.Existing.ForEach(data => current.Find(c => c.No.Equals(data.Value.Target.EntityNo))!.Update(data.Value.Target));

        current.AddRange(target
            .Where(t => t.EntityNo == null)
            .Select(data =>
                new QuizMultipleChoiceQuestion(
                    id,
                    nextNo++,
                    new QuizMultipleChoiceQuestionCreateData(
                        data.OrderNumber,
                        data.Text,
                        data.Answers.Select(a => new QuizClosedQuestionAnswerCreateData(a.OrderNumber, a.Text, a.IsCorrect)).ToArray()
                    )
                )
            )
        );

        return current;
    }
}