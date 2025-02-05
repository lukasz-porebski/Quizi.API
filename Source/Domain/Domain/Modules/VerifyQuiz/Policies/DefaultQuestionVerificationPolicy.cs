using Domain.Modules.Quizzes.Models;
using Domain.Modules.VerifyQuiz.Enums;
using Domain.Modules.VerifyQuiz.MethodData;
using Domain.Modules.VerifyQuiz.MethodData.Sub;
using Domain.Modules.VerifyQuiz.Policies.Core;

namespace Domain.Modules.VerifyQuiz.Policies;

internal class DefaultQuestionVerificationPolicy : QuestionVerificationBase, IQuestionVerificationPolicy
{
    public QuizQuestionVerificationResultData VerifyOpenEndedQuestion(
        QuizOpenQuestionVerificationData userAnswer, QuizOpenQuestion question) =>
        new(question.No,
            ScoredPoints: userAnswer.IsCorrect.HasValue && userAnswer.IsCorrect.Value ? 1 : 0,
            PointsPossibleToGet: 1);

    public QuizQuestionVerificationResultData VerifySingleChoiceQuestion(
        QuizSingleChoiceQuestionVerificationData userAnswer, QuizSingleChoiceQuestion question)
    {
        var verifiedQuestion = GetVerifiedSingleChoiceQuestion(userAnswer, question);

        return new QuizQuestionVerificationResultData(
            question.No,
            ScoredPoints: verifiedQuestion == SingleChoiceQuestionVerificationResultType.MarkedCorrectAnswer ? 1 : 0,
            PointsPossibleToGet: 1);
    }

    public QuizQuestionVerificationResultData VerifyMultipleChoiceQuestion(
        QuizMultipleChoiceQuestionVerificationData userAnswers, QuizMultipleChoiceQuestion question)
    {
        var verifiedQuestion = GetVerifiedMultipleChoiceQuestion(userAnswers, question);
        var points = verifiedQuestion.NumberOfCorrectAnswersMarked - verifiedQuestion.NumberOfWrongAnswersMarked;

        return new QuizQuestionVerificationResultData(
            question.No,
            ScoredPoints: points > 0 ? (float)points / question.GetCorrectAnswers().Count : 0,
            PointsPossibleToGet: 1);
    }
}