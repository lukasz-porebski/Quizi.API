using Application.Contracts.Modules.Quizzes.Dtos;
using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Contracts.Modules.Quizzes.Queries;
using Common.Application.CQRS;

namespace Application.Modules.Quizzes.QueryHandlers;

public class GetQuizDetailsQueryHandler(IQuizDetailsReadModel readModel) : IQueryHandler<GetQuizDetailsQuery, QuizDetailsDto>
{
    public Task<QuizDetailsDto> Handle(GetQuizDetailsQuery query, CancellationToken cancellationToken) =>
        readModel.Get(query, cancellationToken);
}