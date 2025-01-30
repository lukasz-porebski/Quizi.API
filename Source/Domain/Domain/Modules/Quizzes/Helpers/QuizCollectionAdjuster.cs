using Common.Domain.Extensions;
using Domain.Modules.Quizzes.Data.Questions.Create;
using Domain.Modules.Quizzes.Data.Questions.Update;
using Domain.Modules.Quizzes.Models;

namespace Domain.Modules.Quizzes.Helpers;

internal static class QuizCollectionAdjuster
{
    internal static List<OpenEndedQuestionEntity> Adjust(
        this List<OpenEndedQuestionEntity> current, IEnumerable<QuizOpenEndedQuestionUpdateData> target)
    {
        var nextNo = current.NextNo();

        var difference = current.GetDifference(
            k => k.No, target.Where(t => t.EntityNo.HasValue), k => k.EntityNo.Value);

        current.RemoveAll(entity => difference.ToRemove.Contains(entity));

        difference.ToUpdate.ForEach(data => current.Find(c => c.No.Equals(data.EntityNo)).Update(data));

        current.AddRange(target
            .Where(t => !t.EntityNo.HasValue)
            .Select(data => new OpenEndedQuestionEntity(
                nextNo++, new QuizOpenEndedQuestionCreateData(data.OrderNumber, data.Text, data.CorrectAnswer))));

        return current;
    }

    internal static List<SingleChoiceQuestionEntity> Adjust(
        this List<SingleChoiceQuestionEntity> current, IEnumerable<QuizSingleChoiceQuestionUpdateData> target)
    {
        var nextNo = current.NextNo();

        var difference = current.GetDifference(
            k => k.No, target.Where(t => t.EntityNo.HasValue), k => k.EntityNo.Value);

        current.RemoveAll(entity => difference.ToRemove.Contains(entity));

        difference.ToUpdate.ForEach(data => current.Find(c => c.No.Equals(data.EntityNo)).Update(data));

        current.AddRange(target
            .Where(t => !t.EntityNo.HasValue)
            .Select(data => new SingleChoiceQuestionEntity(
                nextNo++, new QuizSingleChoiceQuestionCreateData(
                    data.OrderNumber, data.Text, data.CorrectAnswer, data.WrongAnswers))));

        return current;
    }

    internal static List<MultipleChoiceQuestionEntity> Adjust(
        this List<MultipleChoiceQuestionEntity> current, IEnumerable<QuizMultipleChoiceQuestionUpdateData> target)
    {
        var nextNo = current.NextNo();

        var difference = current.GetDifference(
            k => k.No, target.Where(t => t.EntityNo.HasValue), k => k.EntityNo.Value);

        current.RemoveAll(entity => difference.ToRemove.Contains(entity));

        difference.ToUpdate.ForEach(data => current.Find(c => c.No.Equals(data.EntityNo)).Update(data));

        current.AddRange(target
            .Where(t => !t.EntityNo.HasValue)
            .Select(data => new MultipleChoiceQuestionEntity(
                nextNo++, new QuizMultipleChoiceQuestionCreateData(
                    data.OrderNumber, data.Text, data.CorrectAnswers, data.WrongAnswers))));

        return current;
    }
}