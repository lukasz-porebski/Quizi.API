using Application.Contracts.Modules.QuizResults.Dtos;
using Application.Contracts.Modules.QuizResults.Queries;
using Common.Application.Contracts.ReadModel;
using Common.Domain.ValueObjects;
using Common.Infrastructure.Endpoints;
using Common.PublishedLanguage.Requests;
using Common.PublishedLanguage.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublishedLanguage.Modules.QuizResults.Responses;

namespace Infrastructure.Endpoints.Modules.QuizResults;

[Route("quiz-results"), Authorize]
public class QuizResultController(IGate gate) : BaseController(gate)
{
    [HttpGet("details/{id}")]
    public async Task<ActionResult<QuizResultDetailsResponse>> GetDetails(string id, CancellationToken cancellationToken)
    {
        if (!AggregateId.TryParse(id, out var aggregateId))
            return BadRequest();

        var result = await Gate.DispatchQueryAsync<
            GetQuizResultDetailsQuery,
            QuizResultDetailsDto?,
            QuizResultDetailsResponse?>(
            new GetQuizResultDetailsQuery(aggregateId), cancellationToken);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("list")]
    public async Task<ActionResult<PaginatedListDto<QuizResultsListItemResponse>>> GetList(
        [FromQuery] PaginationRequest request, CancellationToken cancellationToken)
    {
        var result = await Gate.DispatchQueryAsync<
            PaginationRequest,
            GetQuizResultsQuery,
            PaginatedListDto<QuizResultsListItemDto>,
            PaginatedListResponse<QuizResultsListItemResponse>>(
            request, cancellationToken);
        return Ok(result);
    }
}