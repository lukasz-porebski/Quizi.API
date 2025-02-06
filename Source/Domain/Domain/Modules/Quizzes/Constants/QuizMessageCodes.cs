namespace Domain.Modules.Quizzes.Constants;

internal static class QuizMessageCodes
{
    public const string NonUniqueQuestions = nameof(NonUniqueQuestions);
    public const string NonUniqueQuestionAnswers = nameof(NonUniqueQuestionAnswers);
    public const string IncorrectDescriptionLength = nameof(IncorrectDescriptionLength);
    public const string IncorrectTitleLength = nameof(IncorrectTitleLength);
    public const string AnswersContainsQuestionText = nameof(AnswersContainsQuestionText);
    public const string IncorrectQuestionTextLength = nameof(IncorrectQuestionTextLength);
    public const string SelectionQuestionHasNotAtLeastTwoAnswers = nameof(SelectionQuestionHasNotAtLeastTwoAnswers);
    public const string QuizHasNotDefinedAnyQuestion = nameof(QuizHasNotDefinedAnyQuestion);
    public const string QuizIncorrectDefinedQuestionsCountInRunningQuiz = nameof(QuizIncorrectDefinedQuestionsCountInRunningQuiz);
    public const string IncorrectQuizDuration = nameof(IncorrectQuizDuration);
    public const string IncorrectQuestionAnswerTextLength = nameof(IncorrectQuestionAnswerTextLength);
    public const string QuestionMinimalOrdinalNumberIsNotOne = nameof(QuestionMinimalOrdinalNumberIsNotOne);
    public const string QuestionMaximalOrdinalNumberIsEqualToQuestionsCount = nameof(QuestionMaximalOrdinalNumberIsEqualToQuestionsCount);
    public const string QuestionOrdinalNumberIsUnique = nameof(QuestionOrdinalNumberIsUnique);
    public const string QuestionAnswerMinimalOrdinalNumberIsNotOne = nameof(QuestionAnswerMinimalOrdinalNumberIsNotOne);
    public const string QuestionAnswerOrdinalNumberIsUnique = nameof(QuestionAnswerOrdinalNumberIsUnique);
    public const string OneOfNewQuestionsIsAlreadyAdded = nameof(OneOfNewQuestionsIsAlreadyAdded);

    public const string QuestionAnswerMaximalOrdinalNumberIsEqualToQuestionsCount =
        nameof(QuestionAnswerMaximalOrdinalNumberIsEqualToQuestionsCount);
}