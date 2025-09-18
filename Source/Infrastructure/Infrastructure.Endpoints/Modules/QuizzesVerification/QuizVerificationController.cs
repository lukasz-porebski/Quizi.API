using Application.Contracts.Modules.QuizzesVerification.Commands;
using Application.Contracts.Modules.QuizzesVerification.Queries;
using Common.Domain.ValueObjects;
using Common.Infrastructure.Endpoints;
using Microsoft.AspNetCore.Mvc;
using PublishedLanguage.Modules.QuizzesVerification.Requests;
using PublishedLanguage.Modules.QuizzesVerification.Responses;

namespace Infrastructure.Endpoints.Modules.QuizzesVerification;

[Route("quizzes-verification")]
public class QuizVerificationController(IGate gate) : BaseController(gate)
{
    [HttpGet("quiz-to-run/{id}")]
    public async Task<IActionResult> GetQuizToRun(string id, CancellationToken cancellationToken)
    {
        if (!AggregateId.TryParse(id, out var aggregateId))
            return BadRequest();

        var result = await Gate.DispatchQueryAsync<GetQuizToRunQuery, QuizToRunResponse>(
            new GetQuizToRunQuery(aggregateId), cancellationToken);
        return Ok(result);
    }

    [HttpPost("verify")]
    public async Task<IActionResult> Verify([FromBody] VerifyQuizRequest request, CancellationToken cancellationToken)
    {
        await Gate.DispatchCommandAsync<VerifyQuizRequest, VerifyQuizCommand>(request, cancellationToken);
        return Ok();
    }
}