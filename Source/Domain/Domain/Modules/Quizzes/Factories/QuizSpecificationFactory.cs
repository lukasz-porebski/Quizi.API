using Common.Domain.Specification;
using Domain.Modules.Quizzes.Factories.Interfaces;
using Domain.Modules.Quizzes.Specifications.Data;
using Domain.Modules.Quizzes.Specifications.Implementations;
using Domain.Modules.Quizzes.Specifications.Implementations.Questions;
using Domain.Modules.Quizzes.Specifications.Implementations.Questions.QuestionAnswerOrderNumber;
using Domain.Modules.Quizzes.Specifications.Implementations.Questions.QuestionOrderNumber;

namespace Domain.Modules.Quizzes.Factories;

internal class QuizSpecificationFactory : IQuizSpecificationFactory
{
    public SpecificationBuilderDirector QuizPersist(QuizPersistSpecificationData specificationData) =>
        new SpecificationBuilderDirector.SpecificationBuilder<QuizPersistSpecificationData>(specificationData)
            .AndNextIfThisPass(new QuizOwnerSpecification(), v => v)
            .And(new QuizDeclaredQuestionsCountSpecification(), v => v)
            .AndNextIfThisPass(new QuizHasAtLeastOneQuestionSpecification(), v => v.Questions)
            .AndCollection(new QuizQuestionAnswerMaximalOrderNumberIsEqualToQuestionsCountSpecification(), v => v.ClosedEndedQuestions)
            .AndCollection(new QuizQuestionAnswerMinimalOrderNumberIsOneSpecification(), v => v.ClosedEndedQuestions)
            .AndCollection(new QuizQuestionAnswerOrderNumberIsUniqueSpecification(), v => v.ClosedEndedQuestions)
            .AndCollection(new QuizQuestionAnswersAreUniqueSpecification(), v => v.ClosedEndedQuestions)
            .AndCollection(new QuizQuestionAnswersNotContainsQuestionTextSpecification(), v => v.Questions)
            .And(new QuizQuestionMaximalOrderNumberIsEqualToQuestionsCountSpecification(), v => v.Questions)
            .And(new QuizQuestionMinimalOrderNumberIsOneSpecification(), v => v.Questions)
            .And(new QuizQuestionOrderNumberIsUniqueSpecification(), v => v.Questions)
            .And(new QuizQuestionsAreUniqueSpecification(), v => v.Questions)
            .AndCollection(new QuizQuestionTextSpecification(), v => v.ClosedEndedQuestions.Select(q => q.Text))
            .AndCollection(new QuizSelectionQuestionHasAtLeastTwoAnswersSpecification(),
                v => v.ClosedEndedQuestions.Select(q => q.Answers))
            .Build();

    public SpecificationBuilderDirector AddUser(QuizAddUserSpecificationData specificationData) =>
        new SpecificationBuilderDirector.SpecificationBuilder<QuizAddUserSpecificationData>(specificationData)
            .AndNextIfThisPass(new QuizOwnerSpecification(), v => v)
            .And(new QuizAddUserSpecification(), v => v)
            .Build();

    public SpecificationBuilderDirector RemoveUser(QuizRemoveUserSpecificationData specificationData) =>
        new SpecificationBuilderDirector.SpecificationBuilder<QuizRemoveUserSpecificationData>(specificationData)
            .AndNextIfThisPass(new QuizOwnerSpecification(), v => v)
            .And(new QuizUserToRemoveIsNotOwnerSpecification(), v => v)
            .And(new QuizRemoveUserSpecification(), v => v)
            .Build();

    public SpecificationBuilderDirector AddNewQuestions(QuizAddNewQuestionsSpecificationData specificationData) =>
        new SpecificationBuilderDirector.SpecificationBuilder<QuizAddNewQuestionsSpecificationData>(specificationData)
            .AndNextIfThisPass(new QuizOwnerSpecification(), v => v)
            .And(new QuizDeclaredQuestionsCountSpecification(), v => v)
            .AndNextIfThisPass(new QuizHasAtLeastOneQuestionSpecification(), v => v.Questions.NewQuestions)
            .AndCollection(new QuizQuestionAnswerMaximalOrderNumberIsEqualToQuestionsCountSpecification(),
                v => v.Questions.NewClosedEndedQuestions)
            .AndCollection(new QuizQuestionAnswerMinimalOrderNumberIsOneSpecification(),
                v => v.Questions.NewClosedEndedQuestions)
            .AndCollection(new QuizQuestionAnswerOrderNumberIsUniqueSpecification(),
                v => v.Questions.NewClosedEndedQuestions)
            .AndCollection(new QuizQuestionAnswersAreUniqueSpecification(),
                v => v.Questions.NewClosedEndedQuestions)
            .AndCollection(new QuizQuestionAnswersNotContainsQuestionTextSpecification(), v => v.Questions.NewQuestions)
            .And(new QuizQuestionMaximalOrderNumberIsEqualToQuestionsCountSpecification(), v => v.Questions.NewQuestions)
            .And(new QuizQuestionMinimalOrderNumberIsOneSpecification(), v => v.Questions.NewQuestions)
            .And(new QuizQuestionOrderNumberIsUniqueSpecification(), v => v.Questions.NewQuestions)
            .And(new QuizQuestionsAreUniqueSpecification(), v => v.Questions.NewQuestions)
            .And(new QuizAddNewQuestionsSpecification(), v => v.Questions)
            .AndCollection(new QuizQuestionTextSpecification(),
                v => v.Questions.NewClosedEndedQuestions.Select(q => q.Text))
            .AndCollection(new QuizSelectionQuestionHasAtLeastTwoAnswersSpecification(),
                v => v.Questions.NewClosedEndedQuestions.Select(q => q.Answers))
            .Build();
}