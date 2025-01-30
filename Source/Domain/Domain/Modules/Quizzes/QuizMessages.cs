namespace Domain.Modules.Quizzes;

internal class QuizMessages
{
    private static readonly string ProjectAbbreviation = "";
    private static readonly string ModuleWord = "";

    internal static string NonUniqueQuestions() =>
        Generate(1, "Questions have to be unique");

    internal static string NonUniqueQuestionAnswers() =>
        Generate(2, "Question answers have to be unique");

    internal static string UserHasThisQuiz() =>
        Generate(3, "User already has this quiz");

    internal static string IncorrectDescriptionLength() =>
        Generate(4, "Maximum description length is 200 characters");

    internal static string UserNotHasThisQuiz() =>
        Generate(5, "User does not have this quiz");

    internal static string IncorrectTitleLength() =>
        Generate(6, "Number of characters in title have to be between 5-100");

    internal static string AnswersContainsQuestionText() =>
        Generate(7, "Answers can't contains question text");

    internal static string QuestionTextIsNotDefined() =>
        Generate(8, "Question text is not defined");

    internal static string SelectionQuestionHasNotAtLeastTwoAnswers() =>
        Generate(9, "Closed ended question has to has at least two answers");

    internal static string QuizHasNotDefinedAnyQuestion() =>
        Generate(10, "Quiz has to has defined at least one question");

    internal static string QuizIncorrectDefinedQuestionsCountInRunningQuiz() =>
        Generate(11, "Questions count in running quiz has to be greater than 0 and less or equals to questions count");

    internal static string IncorrectQuizDuration() =>
        Generate(12, "Quiz duration has to be greater than 0 and less or equals to 180 minutes");

    internal static string AnswerOrderNumberLessThanOne() =>
        Generate(13, "Order number of question answer can't be less than one");

    internal static string AnswerIsEmpty() =>
        Generate(14, "Question answer can't be empty");

    internal static string QuestionMinimalOrderNumberIsNotOne() =>
        Generate(15, "Question minimal order number has to be one");

    internal static string QuestionMaximalOrderNumberIsEqualToQuestionsCount() =>
        Generate(16, "Question maximal order number has to be equal to questions count");

    internal static string QuestionOrderNumberIsUnique() =>
        Generate(17, "Question order number has to be unique");

    internal static string QuestionAnswerMinimalOrderNumberIsNotOne() =>
        Generate(18, "Question answer minimal order number has to be one");

    internal static string QuestionAnswerMaximalOrderNumberIsEqualToQuestionsCount() =>
        Generate(19, "Question answer maximal order number has to be equal to answers count");

    internal static string QuestionAnswerOrderNumberIsUnique() =>
        Generate(20, "Question answer order number has to be unique");

    internal static string AccessDenied() =>
        Generate(21, "You don't have access to this quiz");

    internal static string UserToRemoveIsOwner() =>
        Generate(22, "You can't remove user that is owner");

    internal static string IncorrectDeclaredQuestionsCount() =>
        Generate(23, "Declared questions count doesn't match to actual questions count");

    internal static string OneOfNewQuestionsIsAlreadyAdded() =>
        Generate(24, "Quiz already has a question that is declared as new");

    private static string Generate(int orderNumber, string message) =>
        Generate(ModuleWord, ProjectAbbreviation, orderNumber, message);
}