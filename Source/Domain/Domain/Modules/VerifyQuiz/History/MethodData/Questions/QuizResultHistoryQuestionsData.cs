namespace Domain.Modules.VerifyQuiz.History.MethodData.Questions;

public class QuizResultHistoryQuestionsData
{
    public IEnumerable<QuizResultHistoryOpenEndedQuestionData> OpenEndedQuestions { get; }
    public IEnumerable<QuizResultHistorySingleChoiceQuestionData> SingleChoiceQuestions { get; }
    public IEnumerable<QuizResultHistoryMultipleChoiceQuestionData> MultipleChoiceQuestions { get; }

    public QuizResultHistoryQuestionsData(
        IEnumerable<QuizResultHistoryOpenEndedQuestionData> openEndedQuestions,
        IEnumerable<QuizResultHistorySingleChoiceQuestionData> singleChoiceQuestions,
        IEnumerable<QuizResultHistoryMultipleChoiceQuestionData> multipleChoiceQuestions)
    {
        OpenEndedQuestions = openEndedQuestions;
        SingleChoiceQuestions = singleChoiceQuestions;
        MultipleChoiceQuestions = multipleChoiceQuestions;
    }
}