namespace Domain.Modules.Quizzes.Constants;

internal static class QuizMessageCodes
{
    public const string NonUniqueQuestions = nameof(NonUniqueQuestions);
    public const string NonUniqueQuestionAnswers = nameof(NonUniqueQuestionAnswers);
    public const string IncorrectDescriptionLength = nameof(IncorrectDescriptionLength);
    public const string IncorrectTitleLength = nameof(IncorrectTitleLength);
    public const string AnswersContainsQuestionText = nameof(AnswersContainsQuestionText);
    public const string QuestionTextIsNotDefined = nameof(QuestionTextIsNotDefined);
    public const string SelectionQuestionHasNotAtLeastTwoAnswers = nameof(SelectionQuestionHasNotAtLeastTwoAnswers);
    public const string QuizHasNotDefinedAnyQuestion = nameof(QuizHasNotDefinedAnyQuestion);
    public const string QuizIncorrectDefinedQuestionsCountInRunningQuiz = nameof(QuizIncorrectDefinedQuestionsCountInRunningQuiz);
    public const string IncorrectQuizDuration = nameof(IncorrectQuizDuration);
    public const string AnswerOrderNumberLessThanOne = nameof(AnswerOrderNumberLessThanOne);
    public const string AnswerIsEmpty = nameof(AnswerIsEmpty);
    public const string QuestionMinimalOrderNumberIsNotOne = nameof(QuestionMinimalOrderNumberIsNotOne);
    public const string QuestionMaximalOrderNumberIsEqualToQuestionsCount = nameof(QuestionMaximalOrderNumberIsEqualToQuestionsCount);
    public const string QuestionOrderNumberIsUnique = nameof(QuestionOrderNumberIsUnique);
    public const string QuestionAnswerMinimalOrderNumberIsNotOne = nameof(QuestionAnswerMinimalOrderNumberIsNotOne);
    public const string QuestionAnswerOrderNumberIsUnique = nameof(QuestionAnswerOrderNumberIsUnique);
    public const string AccessDenied = nameof(AccessDenied);
    public const string IncorrectDeclaredQuestionsCount = nameof(IncorrectDeclaredQuestionsCount);
    public const string OneOfNewQuestionsIsAlreadyAdded = nameof(OneOfNewQuestionsIsAlreadyAdded);

    public const string QuestionAnswerMaximalOrderNumberIsEqualToQuestionsCount =
        nameof(QuestionAnswerMaximalOrderNumberIsEqualToQuestionsCount);
}