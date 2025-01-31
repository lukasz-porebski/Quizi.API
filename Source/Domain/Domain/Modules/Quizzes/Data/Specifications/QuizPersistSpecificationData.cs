using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Specifications.Questions;
using Domain.Modules.Quizzes.Helpers;
using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Data.Specifications;

public class QuizPersistSpecificationData : IQuizOwnerSpecification, IQuizQuestionsCountSpecification
{
    public int QuestionsCount { get; }
    public int QuestionsCountInRunningQuiz { get; }
    public AggregateId OwnerId { get; }
    public AggregateId UserId { get; }
    public IReadOnlyCollection<QuizClosedEndedQuestionSpecificationData> ClosedEndedQuestions { get; }
    public IReadOnlyCollection<QuizQuestionSpecificationData> Questions { get; }

    internal QuizPersistSpecificationData(
        int questionsCountInRunningQuiz,
        IReadOnlyCollection<QuizOpenEndedQuestionSpecificationData> openEndedQuestions,
        IReadOnlyCollection<QuizSingleChoiceQuestionSpecificationData> singleChoiceQuestions,
        IReadOnlyCollection<QuizMultipleChoiceQuestionSpecificationData> multipleChoiceQuestions,
        AggregateId owner,
        AggregateId userDeclaredAsOwner)
    {
        QuestionsCountInRunningQuiz = questionsCountInRunningQuiz;
        OwnerId = owner;
        UserId = userDeclaredAsOwner;
        ClosedEndedQuestions = QuizSpecificationHelper.GetClosedEndedQuestions(
            singleChoiceQuestions, multipleChoiceQuestions);
        Questions = QuizSpecificationHelper.GetQuestions(
            openEndedQuestions, singleChoiceQuestions, multipleChoiceQuestions);
        QuestionsCount = Questions.Count;
    }
}