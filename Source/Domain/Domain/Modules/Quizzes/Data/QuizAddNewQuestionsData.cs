using Common.Domain.ValueObjects;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Data.Questions.Create;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data;

public class QuizAddNewQuestionsData
{
    public AggregateId UserId { get; }
    public QuizQuestionsCountInRunningQuiz QuestionsCountInRunningQuiz { get; }
    public List<QuizOpenEndedQuestionCreateData> OpenEndedQuestions { get; }
    public List<QuizSingleChoiceQuestionCreateData> SingleChoiceQuestions { get; }
    public List<QuizMultipleChoiceQuestionCreateData> MultipleChoiceQuestions { get; }

    public QuizAddNewQuestionsData(
        AggregateId userId,
        QuizQuestionsCountInRunningQuiz questionsCountInRunningQuiz,
        IEnumerable<QuizOpenEndedQuestionCreateData> openEndedQuestions,
        IEnumerable<QuizSingleChoiceQuestionCreateData> singleChoiceQuestions,
        IEnumerable<QuizMultipleChoiceQuestionCreateData> multipleChoiceQuestions)
    {
        UserId = userId;
        QuestionsCountInRunningQuiz = questionsCountInRunningQuiz;
        OpenEndedQuestions = openEndedQuestions.CreateList();
        SingleChoiceQuestions = singleChoiceQuestions.CreateList();
        MultipleChoiceQuestions = multipleChoiceQuestions.CreateList();
    }
}