using Common.Domain.Specification;
using Domain.Modules.VerifyQuiz.Specifications.Data;

namespace Domain.Modules.VerifyQuiz.Factories;

internal interface IVerifyQuizSpecificationFactory
{
    SpecificationBuilderDirector VerifyQuiz(VerifiedQuizSpecificationData specificationData);
}