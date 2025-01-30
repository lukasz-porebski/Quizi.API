using Common.Domain.Extensions;
using Common.Domain.ValueObjects;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Data.Questions.Create;
using Domain.Modules.Quizzes.Data.Questions.Update;
using Domain.Modules.Quizzes.Models;
using MoreLinq;

namespace Domain.Modules.Quizzes.Helpers;

internal static class QuizCollectionAdjuster
{
    internal static List<OpenEndedQuestion> Adjust(
        this List<OpenEndedQuestion> current,
        AggregateId id,
        IReadOnlyCollection<QuizOpenEndedQuestionUpdateData> target)
    {
        var nextNo = current.NextNo();

        var difference = current.GetDifferences(
            k => k.No, target.Where(t => t.EntityNo != null).ToArray(), k => k.EntityNo!);

        current.RemoveAll(entity => difference.ToRemove.Contains(entity));

        difference.Existing.ForEach(data => current.Find(c => c.No.Equals(data.Value.Target.EntityNo))!.Update(data.Value.Target));

        current.AddRange(target
            .Where(t => t.EntityNo == null)
            .Select(data => new OpenEndedQuestion(
                id, nextNo++, new QuizOpenEndedQuestionCreateData(data.OrderNumber, data.Text, data.CorrectAnswer))));

        return current;
    }

    internal static List<SingleChoiceQuestion> Adjust(
        this List<SingleChoiceQuestion> current,
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
            .Select(data => new SingleChoiceQuestion(
                id, nextNo++, new QuizSingleChoiceQuestionCreateData(
                    data.OrderNumber, data.Text, data.CorrectAnswer, data.WrongAnswers))));

        return current;
    }

    internal static List<MultipleChoiceQuestion> Adjust(
        this List<MultipleChoiceQuestion> current,
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
            .Select(data => new MultipleChoiceQuestion(
                id, nextNo++, new QuizMultipleChoiceQuestionCreateData(
                    data.OrderNumber, data.Text, data.CorrectAnswers, data.WrongAnswers))));

        return current;
    }
}