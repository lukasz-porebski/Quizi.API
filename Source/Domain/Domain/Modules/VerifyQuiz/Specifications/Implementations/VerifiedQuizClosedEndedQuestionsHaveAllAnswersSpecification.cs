using Common.Domain.Specification;
using Common.Shared.Extensions;
using Domain.Modules.VerifyQuiz.Specifications.Data;

namespace Domain.Modules.VerifyQuiz.Specifications.Implementations;

internal class VerifiedQuizClosedEndedQuestionsHaveAllAnswersSpecification
    : ISpecification<VerifiedQuizClosedEndedQuestionSpecificationData>
{
    public string FailureMessageCode => VerifyQuizMessages.VerifiedQuizChoiceQuestionsHaveAllAnswers;

    public bool IsValid(VerifiedQuizClosedEndedQuestionSpecificationData data) =>
        data.QuizQuestionAnswers.Select(a => a.Text)
            .CollectionEqual(data.AllValidatedAnswers.Select(a => a.Text));
}