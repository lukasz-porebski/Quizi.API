using Common.Domain.Specification;
using Domain.Modules.VerifyQuiz.Specifications.Data;
using Domain.Modules.VerifyQuiz.Specifications.Implementations;
using Domain.Modules.VerifyQuiz.Specifications.Implementations.QuestionAnswerOrderNumber;
using Domain.Modules.VerifyQuiz.Specifications.Implementations.QuestionOrderNumber;

namespace Domain.Modules.VerifyQuiz.Factories;

internal class VerifyQuizSpecificationFactory : IVerifyQuizSpecificationFactory
{
    public SpecificationBuilderDirector VerifyQuiz(VerifiedQuizSpecificationData specificationData) =>
        new SpecificationBuilderDirector.SpecificationBuilder<VerifiedQuizSpecificationData>(specificationData)
            .And(new VerifiedQuizHasDeclaredQuestionsSpecification(), v => v)
            .And(new VerifiedQuizQuestionMaximalOrderNumberIsEqualToVerifiedQuestionsCountSpecification(),
                v => v.VerifyQuizQuestions)
            .And(new VerifiedQuizQuestionMinimalOrderNumberIsOneSpecification(), v => v.VerifyQuizQuestions)
            .And(new VerifiedQuizQuestionOrderNumberIsUniqueSpecification(), v => v.VerifyQuizQuestions)
            .AndCollection(new VerifiedQuizClosedEndedQuestionsHaveAllAnswersSpecification(),
                v => v.ClosedEndedQuestions)
            .AndCollection(
                new VerifiedQuizQuestionAnswerMaximalOrderNumberIsEqualToVerifiedQuestionsCountSpecification(),
                v => v.ClosedEndedQuestions)
            .AndCollection(new VerifiedQuizQuestionAnswerMinimalOrderNumberIsOneSpecification(),
                v => v.ClosedEndedQuestions)
            .AndCollection(new VerifiedQuizQuestionAnswerOrderNumberIsUniqueSpecification(),
                v => v.ClosedEndedQuestions)
            .Build();
}