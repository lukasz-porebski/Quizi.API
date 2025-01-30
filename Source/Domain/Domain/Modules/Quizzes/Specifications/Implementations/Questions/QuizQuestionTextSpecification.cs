using Common.Domain.Specification;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions;

internal class QuizQuestionTextSpecification : ISpecification<string>
{
    public string FailureMessageCode => QuizMessages.QuestionTextIsNotDefined();

    public bool IsValid(string data) => data.Any();
}