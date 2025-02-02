using Common.Domain.Specification;
using Domain.Modules.Quizzes.Data.Specifications;
using Domain.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.Specifications;
using Domain.Modules.Quizzes.Specifications.Questions;
using Domain.Modules.Quizzes.Specifications.Questions.AnswerOrderNumber;
using Domain.Modules.Quizzes.Specifications.Questions.OrderNumber;
using Domain.Shared.Specifications;

namespace Domain.Modules.Quizzes.Factories;

internal class QuizSpecificationFactory : IQuizSpecificationFactory
{
    public SpecificationBuilderDirector QuizPersist(QuizPersistSpecificationData data) =>
        new SpecificationBuilderDirector.SpecificationBuilder<QuizPersistSpecificationData>(data)
            .AndNextIfThisPass(new OwnerSpecification())
            .And(new QuizDescriptionSpecification(), v => v.Description)
            .And(new QuizDurationSpecification(), v => v.Duration)
            .And(new QuizDeclaredQuestionsCountSpecification())
            .And(new QuizQuestionsCountInRunningQuizSpecification())
            .AndNextIfThisPass(new QuizHasAtLeastOneQuestionSpecification(), v => v.Questions)
            .AndCollection(new QuizQuestionAnswerMaxOrderNumberIsEqualToQuestionsCountSpecification(), v => v.ClosedQuestions)
            .AndCollection(new QuizQuestionAnswerMinOrderNumberIsOneSpecification(), v => v.ClosedQuestions)
            .AndCollection(new QuizQuestionAnswerOrderNumberIsUniqueSpecification(), v => v.ClosedQuestions)
            .AndCollection(new QuizQuestionAnswersAreUniqueSpecification(), v => v.ClosedQuestions)
            .AndCollection(new QuizQuestionAnswersNotContainsQuestionTextSpecification(), v => v.Questions)
            .And(new QuizQuestionMaxOrderNumberIsEqualToQuestionsCountSpecification(), v => v.Questions)
            .And(new QuizQuestionMinOrderNumberIsOneSpecification(), v => v.Questions)
            .And(new QuizQuestionOrderNumberIsUniqueSpecification(), v => v.Questions)
            .And(new QuizQuestionsAreUniqueSpecification(), v => v.Questions)
            .AndCollection(new QuizQuestionTextSpecification(), v => v.ClosedQuestions.Select(q => q.Text))
            .AndCollection(new QuizSelectionQuestionHasAtLeastTwoAnswersSpecification(), v => v.ClosedQuestions.Select(q => q.Answers))
            .AndCollection(new QuizQuestionAnswerTextSpecification(), v => v.Questions.SelectMany(q => q.Answers))
            .Build();

    public SpecificationBuilderDirector AddNewQuestions(QuizAddNewQuestionsSpecificationData data) =>
        new SpecificationBuilderDirector.SpecificationBuilder<QuizAddNewQuestionsSpecificationData>(data)
            .AndNextIfThisPass(new OwnerSpecification())
            .And(new QuizDeclaredQuestionsCountSpecification())
            .AndNextIfThisPass(new QuizHasAtLeastOneQuestionSpecification(), v => v.Questions.NewQuestions)
            .AndCollection(new QuizQuestionAnswerMaxOrderNumberIsEqualToQuestionsCountSpecification(),
                v => v.Questions.NewClosedQuestions)
            .AndCollection(new QuizQuestionAnswerMinOrderNumberIsOneSpecification(),
                v => v.Questions.NewClosedQuestions)
            .AndCollection(new QuizQuestionAnswerOrderNumberIsUniqueSpecification(),
                v => v.Questions.NewClosedQuestions)
            .AndCollection(new QuizQuestionAnswersAreUniqueSpecification(),
                v => v.Questions.NewClosedQuestions)
            .AndCollection(new QuizQuestionAnswersNotContainsQuestionTextSpecification(), v => v.Questions.NewQuestions)
            .And(new QuizQuestionMaxOrderNumberIsEqualToQuestionsCountSpecification(), v => v.Questions.NewQuestions)
            .And(new QuizQuestionMinOrderNumberIsOneSpecification(), v => v.Questions.NewQuestions)
            .And(new QuizQuestionOrderNumberIsUniqueSpecification(), v => v.Questions.NewQuestions)
            .And(new QuizQuestionsAreUniqueSpecification(), v => v.Questions.NewQuestions)
            .And(new QuizAddNewQuestionsSpecification(), v => v.Questions)
            .AndCollection(new QuizQuestionTextSpecification(),
                v => v.Questions.NewClosedQuestions.Select(q => q.Text))
            .AndCollection(new QuizSelectionQuestionHasAtLeastTwoAnswersSpecification(),
                v => v.Questions.NewClosedQuestions.Select(q => q.Answers))
            .Build();
}