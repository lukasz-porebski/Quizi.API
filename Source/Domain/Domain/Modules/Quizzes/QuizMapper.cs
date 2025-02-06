using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models;
using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.Data.Specifications;
using Domain.Modules.Quizzes.Data.Specifications.Sub;
using Domain.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.Models;
using Domain.Modules.Quizzes.Models.Base;

namespace Domain.Modules.Quizzes;

public static class QuizMapper
{
    public static QuizClosedQuestionAnswerPersistData ToPersistData(this BaseQuizClosedQuestionAnswer source) =>
        new(source.OrdinalNumber, source.Text, source.IsCorrect);

    public static QuizClosedQuestionCreateData ToCreateData(
        this QuizClosedQuestionPersistData source, int? ordinalNumber = null) =>
        new(ordinalNumber ?? source.OrdinalNumber, source.Text, source.Answers.Select(a => a.Data).ToArray());

    internal static QuizPersistSpecificationData ToSpecificationData(this IQuizPersistData source, AggregateId ownerId) =>
        new(source.Settings.QuestionsCountInRunningQuiz,
            source.Title,
            source.Description,
            source.Settings.Duration,
            source.OpenQuestions,
            source.SingleChoiceQuestions,
            source.MultipleChoiceQuestions,
            ownerId,
            source.OwnerId
        );

    internal static QuizAddNewQuestionsSpecificationData ToSpecificationData(
        this QuizAddNewQuestionsData source,
        AggregateId ownerId,
        IReadOnlyList<QuizOpenQuestion> oldOpenQuestions,
        IReadOnlyList<QuizSingleChoiceQuestion> oldSingleChoiceQuestions,
        IReadOnlyList<QuizMultipleChoiceQuestion> oldMultipleChoiceQuestions) =>
        new(source.QuestionsCountInRunningQuiz,
            new QuizQuestionsForAddNewQuestionsSpecificationData(
                source.OpenQuestions,
                source.SingleChoiceQuestions,
                source.MultipleChoiceQuestions,
                oldOpenQuestions,
                oldSingleChoiceQuestions,
                oldMultipleChoiceQuestions),
            ownerId,
            source.UserId);
}