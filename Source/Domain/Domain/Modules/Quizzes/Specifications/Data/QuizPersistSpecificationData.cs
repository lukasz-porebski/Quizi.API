using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Helpers;
using Domain.Modules.Quizzes.Specifications.Data.Questions;
using Domain.Modules.Quizzes.Specifications.Interfaces;

namespace Domain.Modules.Quizzes.Specifications.Data;

public class QuizPersistSpecificationData : IQuizOwnerSpecification, IQuizQuestionsCountSpecification
{
    public int QuestionsCount { get; }
    public int QuestionsCountInRunningQuiz { get; }
    internal IEnumerable<QuizClosedEndedQuestionSpecificationData> ClosedEndedQuestions { get; }
    internal IEnumerable<QuizQuestionSpecificationData> Questions { get; }
    public AggregateId OwnerId { get; }
    public AggregateId UserId { get; }

    internal QuizPersistSpecificationData(
        int questionsCountInRunningQuiz,
        IEnumerable<QuizOpenEndedQuestionSpecificationData> openEndedQuestions,
        IEnumerable<QuizSingleChoiceQuestionSpecificationData> singleChoiceQuestions,
        IEnumerable<QuizMultipleChoiceQuestionSpecificationData> multipleChoiceQuestions,
        AggregateId owner, AggregateId userDeclaredAsOwner)
    {
        QuestionsCountInRunningQuiz = questionsCountInRunningQuiz;
        OwnerId = owner;
        UserId = userDeclaredAsOwner;
        ClosedEndedQuestions = QuizSpecificationHelper.GetClosedEndedQuestions(
            singleChoiceQuestions, multipleChoiceQuestions);
        Questions = QuizSpecificationHelper.GetQuestions(
            openEndedQuestions, singleChoiceQuestions, multipleChoiceQuestions);
        QuestionsCount = Questions.Count();
    }
}