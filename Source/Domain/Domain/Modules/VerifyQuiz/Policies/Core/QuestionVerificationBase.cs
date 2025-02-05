using Domain.Modules.Quizzes.Models;
using Domain.Modules.VerifyQuiz.Enums;
using Domain.Modules.VerifyQuiz.MethodData.Sub;
using Domain.Modules.VerifyQuiz.Policies.Data;

namespace Domain.Modules.VerifyQuiz.Policies.Core;

internal abstract class QuestionVerificationBase
{
    protected SingleChoiceQuestionVerificationResultType GetVerifiedSingleChoiceQuestion(
        QuizSingleChoiceQuestionVerificationData userAnswer, QuizSingleChoiceQuestion question)
    {
        if (userAnswer.SelectedAnswerNo == null)
            return SingleChoiceQuestionVerificationResultType.NoAnswerMarked;

        return question.GetCorrectAnswer().SubNo == userAnswer.SelectedAnswerNo
            ? SingleChoiceQuestionVerificationResultType.MarkedCorrectAnswer
            : SingleChoiceQuestionVerificationResultType.MarkedWrongAnswer;
    }

    protected MultipleChoiceQuestionVerificationResultData GetVerifiedMultipleChoiceQuestion(
        QuizMultipleChoiceQuestionVerificationData userAnswers, QuizMultipleChoiceQuestion question)
    {
        var numberOfCorrectAnswersMarked = userAnswers.SelectedAnswerNos.Count(a =>
            question.GetCorrectAnswers().Any(c => c.SubNo == a));
        return new MultipleChoiceQuestionVerificationResultData(
            NumberOfCorrectAnswersMarked: numberOfCorrectAnswersMarked,
            NumberOfWrongAnswersMarked: question.Answers.Count - numberOfCorrectAnswersMarked
        );
    }
}