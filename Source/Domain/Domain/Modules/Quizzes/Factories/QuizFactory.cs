using Domain.Modules.Quizzes.Data.Models;
using Domain.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.Models;

namespace Domain.Modules.Quizzes.Factories;

public class QuizFactory : IQuizFactory
{
    private readonly IQuizSpecificationFactory _quizSpecificationFactory;

    public QuizFactory(IQuizSpecificationFactory quizSpecificationFactory)
    {
        _quizSpecificationFactory = quizSpecificationFactory;
    }

    public Quiz Create(QuizCreateData data) => new(_quizSpecificationFactory, data);
}