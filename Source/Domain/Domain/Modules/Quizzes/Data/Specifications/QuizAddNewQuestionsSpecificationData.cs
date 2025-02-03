using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Specifications.Sub;
using Domain.Modules.Quizzes.Interfaces;
using Domain.Shared.Interfaces;

namespace Domain.Modules.Quizzes.Data.Specifications;

public record QuizAddNewQuestionsSpecificationData(
    int QuestionsCountInRunningQuiz,
    QuizQuestionsForAddNewQuestionsSpecificationData Questions,
    AggregateId OwnerId,
    AggregateId UserId
) : IOwnerSpecification, IQuizQuestionsCountSpecification
{
    public int QuestionsCount => Questions.NewQuestions.Count + Questions.OldQuestions.Count;
}