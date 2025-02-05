namespace Domain.Modules.VerifyQuiz;

internal static class VerifyQuizMessages
{
    public const string VerifiedQuizHasDeclaredQuestions = nameof(VerifiedQuizHasDeclaredQuestions);
    public const string VerifiedQuizChoiceQuestionsHaveAllAnswers = nameof(VerifiedQuizChoiceQuestionsHaveAllAnswers);
    public const string VerifiedQuestionMinimalOrderNumberIsNotOne = nameof(VerifiedQuestionMinimalOrderNumberIsNotOne);
    public const string VerifiedQuestionOrderNumberIsUnique = nameof(VerifiedQuestionOrderNumberIsUnique);
    public const string VerifiedQuestionAnswerMinimalOrderNumberIsNotOne = nameof(VerifiedQuestionAnswerMinimalOrderNumberIsNotOne);
    public const string VerifiedQuestionAnswerOrderNumberIsUnique = nameof(VerifiedQuestionAnswerOrderNumberIsUnique);
    public const string QuizNotFound = nameof(QuizNotFound);

    public const string VerifiedQuestionMaximalOrderNumberIsEqualToVerifiedQuestionsCount =
        nameof(VerifiedQuestionMaximalOrderNumberIsEqualToVerifiedQuestionsCount);
}