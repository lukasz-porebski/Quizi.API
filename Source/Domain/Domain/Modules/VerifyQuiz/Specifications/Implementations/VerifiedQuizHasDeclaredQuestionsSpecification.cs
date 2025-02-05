using Common.Domain.Specification;
using Domain.Modules.Quizzes.Models;
using Domain.Modules.VerifyQuiz.MethodData.Sub;
using Domain.Modules.VerifyQuiz.Specifications.Data;

namespace Domain.Modules.VerifyQuiz.Specifications.Implementations;

internal class VerifiedQuizHasDeclaredQuestionsSpecification : ISpecification<VerifiedQuizSpecificationData>
{
    public string FailureMessageCode => VerifyQuizMessages.VerifiedQuizHasDeclaredQuestions;

    public bool IsValid(VerifiedQuizSpecificationData data) =>
        VerifiedQuizHasDeclaredOpenQuestions(data.OpenQuestions, data.VerifiedOpenQuestions) &&
        VerifiedQuizHasDeclaredSingleChoiceQuestions(data.SingleChoiceQuestions, data.VerifiedSingleChoiceQuestions) &&
        VerifiedQuizHasDeclaredMultipleChoiceQuestions(data.MultipleChoiceQuestions, data.VerifiedMultipleChoiceQuestions);

    private static bool VerifiedQuizHasDeclaredOpenQuestions(
        IReadOnlyCollection<QuizOpenQuestion> questions,
        IReadOnlyCollection<QuizOpenQuestionVerificationData> verifiedQuestions) =>
        !verifiedQuestions.Any(verifiedQuestion => questions.Any(q => q.No.Equals(verifiedQuestion.No)));

    private static bool VerifiedQuizHasDeclaredSingleChoiceQuestions(
        IReadOnlyCollection<QuizSingleChoiceQuestion> questions,
        IReadOnlyCollection<QuizSingleChoiceQuestionVerificationData> verifiedQuestions) =>
        !verifiedQuestions.Any(verifiedQuestion => questions.Any(q => q.No.Equals(verifiedQuestion.No)));

    private static bool VerifiedQuizHasDeclaredMultipleChoiceQuestions(
        IReadOnlyCollection<QuizMultipleChoiceQuestion> questions,
        IReadOnlyCollection<QuizMultipleChoiceQuestionVerificationData> verifiedQuestions) =>
        !verifiedQuestions.Any(verifiedQuestion => questions.Any(q => q.No.Equals(verifiedQuestion.No)));
}