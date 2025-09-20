using Application.Contracts.Modules.QuizResults.Dtos;
using Application.Contracts.Modules.QuizResults.Queries;
using Common.Domain.ValueObjects;
using Common.Infrastructure.Endpoints;
using Microsoft.AspNetCore.Mvc;
using PublishedLanguage.Modules.QuizResults.Responses;

namespace Infrastructure.Endpoints.Modules.QuizResults;

[Route("quiz-results")]
public class QuizResultController(IGate gate) : BaseController(gate)
{
    [HttpGet("details/{id}")]
    public async Task<ActionResult<QuizResultDetailsResponse>> GetDetails(string id, CancellationToken cancellationToken)
    {
        if (!AggregateId.TryParse(id, out var aggregateId))
            return BadRequest();

        var result = await Gate.DispatchQueryAsync<
            GetQuizResultDetailsQuery,
            QuizResultDetailsDto,
            QuizResultDetailsResponse>(
            new GetQuizResultDetailsQuery(aggregateId), cancellationToken);
        return Ok(result);
    }
}