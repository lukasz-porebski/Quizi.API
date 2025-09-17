namespace Domain.Modules.Quizzes.Constants;

internal static class QuizMessageCodes
{
    public const string QuestionsHaveToBeUnique = nameof(QuestionsHaveToBeUnique);
    public const string QuestionAnswersHaveToBeUnique = nameof(QuestionAnswersHaveToBeUnique);
    public const string DescriptionLengthIsTooLong = nameof(DescriptionLengthIsTooLong);
    public const string IncorrectTitleLength = nameof(IncorrectTitleLength);
    public const string IncorrectQuestionTextLength = nameof(IncorrectQuestionTextLength);
    public const string ClosedQuestionHasToHasAtLeastTwoAnswers = nameof(ClosedQuestionHasToHasAtLeastTwoAnswers);
    public const string QuizHasToHasAtLeastOneQuestion = nameof(QuizHasToHasAtLeastOneQuestion);
    public const string QuizQuestionsCountInRunningQuizIsOutOfRange = nameof(QuizQuestionsCountInRunningQuizIsOutOfRange);
    public const string QuizDurationIsOutOfRange = nameof(QuizDurationIsOutOfRange);
    public const string IncorrectQuestionAnswerTextLength = nameof(IncorrectQuestionAnswerTextLength);
    public const string QuestionMinOrdinalNumberHasToBeOne = nameof(QuestionMinOrdinalNumberHasToBeOne);

    public const string QuestionMaxOrdinalNumberHasToBeQuestionsCount =
        nameof(QuestionMaxOrdinalNumberHasToBeQuestionsCount);

    public const string QuestionOrdinalNumberHasToBeUnique = nameof(QuestionOrdinalNumberHasToBeUnique);
    public const string QuestionAnswerMinOrdinalNumberHasToBeOne = nameof(QuestionAnswerMinOrdinalNumberHasToBeOne);
    public const string QuestionAnswerOrdinalNumberHasToBeUnique = nameof(QuestionAnswerOrdinalNumberHasToBeUnique);
    public const string OneOfNewQuestionsIsAlreadyAdded = nameof(OneOfNewQuestionsIsAlreadyAdded);

    public const string QuestionAnswerMaxOrdinalNumberHasToBeQuestionsCount =
        nameof(QuestionAnswerMaxOrdinalNumberHasToBeQuestionsCount);
}