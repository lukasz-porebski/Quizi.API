using Common.Domain.Specification;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Models;
using Domain.Modules.VerifyQuiz.MethodData.Questions;
using Domain.Modules.VerifyQuiz.Specifications.Data;

namespace Domain.Modules.VerifyQuiz.Specifications.Implementations;

internal class VerifiedQuizHasDeclaredQuestionsSpecification : ISpecification<VerifiedQuizSpecificationData>
{
    public string FailureMessageCode => VerifyQuizMessages.VerifiedQuizHasDeclaredQuestions;

    public bool IsValid(VerifiedQuizSpecificationData data) =>
        VerifiedQuizHasDeclaredOpenEndedQuestions(data.OpenEndedQuestions, data.VerifiedOpenEndedQuestions) &&
        VerifiedQuizHasDeclaredSingleChoiceQuestions(data.SingleChoiceQuestions, data.VerifiedSingleChoiceQuestions) &&
        VerifiedQuizHasDeclaredMultipleChoiceQuestions(data.MultipleChoiceQuestions, data.VerifiedMultipleChoiceQuestions);

    private static bool VerifiedQuizHasDeclaredOpenEndedQuestions(
        List<QuizOpenQuestion> openEndedQuestions,
        IEnumerable<VerifyQuizOpenEndedQuestionData> verifiedOpenEndedQuestions) =>
        !verifiedOpenEndedQuestions.Any(verifiedQuestion => openEndedQuestions.NotExists(q => q.No.Equals(verifiedQuestion.No)));

    private static bool VerifiedQuizHasDeclaredSingleChoiceQuestions(
        List<QuizSingleChoiceQuestion> singleChoiceQuestions,
        IEnumerable<VerifyQuizSingleChoiceQuestionData> verifiedSingleChoiceQuestions) =>
        !verifiedSingleChoiceQuestions.Any(verifiedQuestion => singleChoiceQuestions.NotExists(q => q.No.Equals(verifiedQuestion.No)));

    private static bool VerifiedQuizHasDeclaredMultipleChoiceQuestions(
        List<QuizMultipleChoiceQuestion> multiplyChoiceQuestions,
        IEnumerable<VerifyQuizMultipleChoiceQuestionData> verifiedMultiplyChoiceQuestions) =>
        !verifiedMultiplyChoiceQuestions.Any(verifiedQuestion =>
            multiplyChoiceQuestions.NotExists(q => q.No.Equals(verifiedQuestion.No)));
}