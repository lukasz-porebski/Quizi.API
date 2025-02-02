using Domain.Modules.Quizzes.Data.Models;
using Domain.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.Models;

namespace Domain.Modules.Quizzes.Factories;

public class QuizFactory(IQuizSpecificationFactory specificationFactory) : IQuizFactory
{
    public Quiz Create(QuizCreateData data) =>
        new(data, specificationFactory);
}