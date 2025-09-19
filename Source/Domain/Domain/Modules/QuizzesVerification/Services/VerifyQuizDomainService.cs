using Common.Domain.Exceptions;
using Common.Shared.Attributes;
using Domain.Modules.Quizzes.Models;
using Domain.Modules.QuizzesVerification.Constants;
using Domain.Modules.QuizzesVerification.Data;
using Domain.Modules.QuizzesVerification.Data.Sub;
using Domain.Modules.QuizzesVerification.Interfaces;

namespace Domain.Modules.QuizzesVerification.Services;

[Service]
public class VerifyQuizDomainService(IQuizVerificationPolicyFactory policyFactory) : IVerifyQuizDomainService
{
    public QuizVerificationResultData Verify(QuizVerificationData data)
    {
        if (!IsValid(data))
            throw new DomainLogicException(VerifyQuizMessages.VerifiedQuizHasDeclaredQuestions);

        return new QuizVerificationResultData(
            VerifyOpenQuestions(data),
            VerifySingleChoiceQuestions(data),
            VerifyMultipleChoiceQuestions(data)
        );
    }

    private IReadOnlyCollection<QuizQuestionVerificationResultData> VerifyOpenQuestions(QuizVerificationData data)
    {
        var policy = policyFactory.CreateForOpenQuestion(data.Quiz.Settings.NegativePoints);
        return data.OpenQuestions
            .Select(o => policy.Verify(o, data.Quiz.OpenQuestions.First(q => q.No == o.No)))
            .ToArray();
    }

    private IReadOnlyCollection<QuizQuestionVerificationResultData> VerifySingleChoiceQuestions(QuizVerificationData data)
    {
        var policy = policyFactory.CreateForSingleChoiceQuestion(data.Quiz.Settings.NegativePoints);
        return data.SingleChoiceQuestions
            .Select(o => policy.Verify(o, data.Quiz.SingleChoiceQuestions.First(q => q.No == o.No)))
            .ToArray();
    }

    private IReadOnlyCollection<QuizQuestionVerificationResultData> VerifyMultipleChoiceQuestions(QuizVerificationData data)
    {
        var policy = policyFactory.CreateForMultipleChoiceQuestion(data.Quiz.Settings.NegativePoints);
        return data.MultipleChoiceQuestions
            .Select(o => policy.Verify(o, data.Quiz.MultipleChoiceQuestions.First(q => q.No == o.No)))
            .ToArray();
    }

    private static bool IsValid(QuizVerificationData data) =>
        VerifiedQuizHasDeclaredOpenQuestions(data.Quiz.OpenQuestions, data.OpenQuestions) &&
        VerifiedQuizHasDeclaredSingleChoiceQuestions(data.Quiz.SingleChoiceQuestions, data.SingleChoiceQuestions) &&
        VerifiedQuizHasDeclaredMultipleChoiceQuestions(data.Quiz.MultipleChoiceQuestions, data.MultipleChoiceQuestions);

    private static bool VerifiedQuizHasDeclaredOpenQuestions(
        IReadOnlyCollection<QuizOpenQuestion> questions,
        IReadOnlyCollection<QuizOpenQuestionVerificationData> verifiedQuestions) =>
        verifiedQuestions.All(verifiedQuestion => questions.Any(q => q.No.Equals(verifiedQuestion.No)));

    private static bool VerifiedQuizHasDeclaredSingleChoiceQuestions(
        IReadOnlyCollection<QuizSingleChoiceQuestion> questions,
        IReadOnlyCollection<QuizSingleChoiceQuestionVerificationData> verifiedQuestions) =>
        verifiedQuestions.All(verifiedQuestion => questions.Any(q => q.No.Equals(verifiedQuestion.No)));

    private static bool VerifiedQuizHasDeclaredMultipleChoiceQuestions(
        IReadOnlyCollection<QuizMultipleChoiceQuestion> questions,
        IReadOnlyCollection<QuizMultipleChoiceQuestionVerificationData> verifiedQuestions) =>
        verifiedQuestions.All(verifiedQuestion => questions.Any(q => q.No.Equals(verifiedQuestion.No)));
}