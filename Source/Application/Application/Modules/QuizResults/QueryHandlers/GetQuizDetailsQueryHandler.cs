using Application.Contracts.Modules.QuizResults.Dtos;
using Application.Contracts.Modules.QuizResults.Interfaces;
using Application.Contracts.Modules.QuizResults.Queries;
using Common.Application.CQRS;

namespace Application.Modules.QuizResults.QueryHandlers;

public class GetQuizDetailsQueryHandler(IQuizResultDetailsReadModel readModel)
    : IQueryHandler<GetQuizResultDetailsQuery, QuizResultDetailsDto>
{
    public Task<QuizResultDetailsDto> Handle(GetQuizResultDetailsQuery query, CancellationToken cancellationToken) =>
        readModel.Get(query, cancellationToken);
}