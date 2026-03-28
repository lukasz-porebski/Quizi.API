using Application.Contracts.Modules.QuizResults.Dtos;
using Application.Contracts.Modules.QuizResults.Queries;
using Infrastructure.Endpoints.Modules.QuizResults.Responses;
using LP.Common.Application.Contracts.ReadModel;
using LP.Common.Domain.ValueObjects;
using LP.Common.Infrastructure.Endpoints;
using LP.Common.Infrastructure.Endpoints.Requests;
using LP.Common.Infrastructure.Endpoints.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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