using Common.Domain.Specification;
using Domain.Modules.VerifyQuiz.Specifications.Data;
using Domain.Modules.VerifyQuiz.Specifications.Implementations;

namespace Domain.Modules.VerifyQuiz.Factories;

internal class VerifyQuizSpecificationFactory : IVerifyQuizSpecificationFactory
{
    public SpecificationBuilderDirector VerifyQuiz(VerifiedQuizSpecificationData specificationData) =>
        new SpecificationBuilderDirector.SpecificationBuilder<VerifiedQuizSpecificationData>(specificationData)
            .And(new VerifiedQuizHasDeclaredQuestionsSpecification())
            .Build();
}