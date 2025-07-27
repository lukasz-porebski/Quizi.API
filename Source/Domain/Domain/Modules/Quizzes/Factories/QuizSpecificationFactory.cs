using Common.Domain.Specification;
using Common.Shared.Attributes;
using Domain.Modules.Quizzes.Data.Specifications;
using Domain.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.Specifications;
using Domain.Modules.Quizzes.Specifications.Questions;
using Domain.Modules.Quizzes.Specifications.Questions.AnswerOrdinalNumber;
using Domain.Modules.Quizzes.Specifications.Questions.OrdinalNumber;
using Domain.Shared.Specifications;

namespace Domain.Modules.Quizzes.Factories;

[Factory]
public class QuizSpecificationFactory : IQuizSpecificationFactory
{
    public SpecificationBuilderDirector QuizPersist(QuizPersistSpecificationData data) =>
        new SpecificationBuilderDirector.SpecificationBuilder<QuizPersistSpecificationData>(data)
            .AndNextIfThisPass(new OwnerSpecification())
            .And(new QuizTitleSpecification(), v => v.Title)
            .And(new QuizDescriptionSpecification(), v => v.Description)
            .And(new QuizDurationSpecification(), v => v.Duration)
            .And(new QuizDeclaredQuestionsCountSpecification())
            .And(new QuizQuestionsCountInRunningQuizSpecification())
            .AndNextIfThisPass(new QuizHasAtLeastOneQuestionSpecification(), v => v.Questions)
            .AndCollection(new QuizQuestionAnswerMaxOrdinalNumberIsEqualToQuestionsCountSpecification(), v => v.ClosedQuestions)
            .AndCollection(new QuizQuestionAnswerMinOrdinalNumberIsOneSpecification(), v => v.ClosedQuestions)
            .AndCollection(new QuizQuestionAnswerOrdinalNumberIsUniqueSpecification(), v => v.ClosedQuestions)
            .AndCollection(new QuizQuestionAnswersAreUniqueSpecification(), v => v.ClosedQuestions)
            .AndCollection(new QuizQuestionAnswersNotContainsQuestionTextSpecification(), v => v.Questions)
            .And(new QuizQuestionMaxOrdinalNumberIsEqualToQuestionsCountSpecification(), v => v.Questions)
            .And(new QuizQuestionMinOrdinalNumberIsOneSpecification(), v => v.Questions)
            .And(new QuizQuestionOrdinalNumberIsUniqueSpecification(), v => v.Questions)
            .And(new QuizQuestionsAreUniqueSpecification(), v => v.Questions)
            .AndCollection(new QuizQuestionTextSpecification(), v => v.ClosedQuestions.Select(q => q.Text))
            .AndCollection(new QuizSelectionQuestionHasAtLeastTwoAnswersSpecification(),
                v => v.ClosedQuestions.Select(q => q.Answers))
            .AndCollection(new QuizQuestionAnswerTextSpecification(), v => v.Questions.SelectMany(q => q.Answers))
            .Build();

    public SpecificationBuilderDirector AddNewQuestions(QuizAddNewQuestionsSpecificationData data) =>
        new SpecificationBuilderDirector.SpecificationBuilder<QuizAddNewQuestionsSpecificationData>(data)
            .AndNextIfThisPass(new OwnerSpecification())
            .And(new QuizDeclaredQuestionsCountSpecification())
            .AndNextIfThisPass(new QuizHasAtLeastOneQuestionSpecification(), v => v.Questions.NewQuestions)
            .AndCollection(new QuizQuestionAnswerMaxOrdinalNumberIsEqualToQuestionsCountSpecification(),
                v => v.Questions.NewClosedQuestions)
            .AndCollection(new QuizQuestionAnswerMinOrdinalNumberIsOneSpecification(), v => v.Questions.NewClosedQuestions)
            .AndCollection(new QuizQuestionAnswerOrdinalNumberIsUniqueSpecification(), v => v.Questions.NewClosedQuestions)
            .AndCollection(new QuizQuestionAnswersAreUniqueSpecification(), v => v.Questions.NewClosedQuestions)
            .AndCollection(new QuizQuestionAnswersNotContainsQuestionTextSpecification(), v => v.Questions.NewQuestions)
            .And(new QuizQuestionMaxOrdinalNumberIsEqualToQuestionsCountSpecification(), v => v.Questions.NewQuestions)
            .And(new QuizQuestionMinOrdinalNumberIsOneSpecification(), v => v.Questions.NewQuestions)
            .And(new QuizQuestionOrdinalNumberIsUniqueSpecification(), v => v.Questions.NewQuestions)
            .And(new QuizQuestionsAreUniqueSpecification(), v => v.Questions.NewQuestions)
            .And(new QuizAddNewQuestionsSpecification(), v => v.Questions)
            .AndCollection(new QuizQuestionTextSpecification(), v => v.Questions.NewClosedQuestions.Select(q => q.Text))
            .AndCollection(new QuizSelectionQuestionHasAtLeastTwoAnswersSpecification(),
                v => v.Questions.NewClosedQuestions.Select(q => q.Answers))
            .Build();
}