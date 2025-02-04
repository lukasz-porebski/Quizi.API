using Domain.Modules.Quizzes.Models;
using Domain.Modules.VerifyQuiz.History.MethodData.Questions;
using Domain.Modules.VerifyQuiz.MethodData.Questions;

namespace Domain.Modules.VerifyQuiz.Policies.Core;

internal interface IQuestionVerificationPolicy
{
    QuizResultHistoryOpenEndedQuestionData VerifyOpenEndedQuestion(
        VerifyQuizOpenEndedQuestionData userAnswer, QuizOpenQuestion question);

    QuizResultHistorySingleChoiceQuestionData VerifySingleChoiceQuestion(
        VerifyQuizSingleChoiceQuestionData userAnswer, QuizSingleChoiceQuestion question);

    QuizResultHistoryMultipleChoiceQuestionData VerifyMultipleChoiceQuestion(
        VerifyQuizMultipleChoiceQuestionData userAnswers, QuizMultipleChoiceQuestion question);
}