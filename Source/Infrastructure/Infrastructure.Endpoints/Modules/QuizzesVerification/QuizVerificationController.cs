using Application.Contracts.Modules.QuizzesVerification.Commands;
using Application.Contracts.Modules.QuizzesVerification.Queries;
using Common.Domain.ValueObjects;
using Common.Infrastructure.Endpoints;
using Common.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using PublishedLanguage.Modules.QuizzesVerification.Requests;
using PublishedLanguage.Modules.QuizzesVerification.Responses;

namespace Infrastructure.Endpoints.Modules.QuizzesVerification;

[Route("quizzes-verification")]
public class QuizVerificationController(IGate gate) : BaseController(gate)
{
    [HttpGet("quiz-to-run/{id}")]
    public async Task<ActionResult<QuizToRunResponse>> GetQuizToRun(string id, CancellationToken cancellationToken)
    {
        if (!AggregateId.TryParse(id, out var aggregateId))
            return BadRequest();

        var result = await Gate.DispatchQueryAsync<GetQuizToRunQuery, QuizToRunResponse?>(
            new GetQuizToRunQuery(aggregateId), cancellationToken);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("open-questions-answer/{quizId}")]
    public async Task<ActionResult<QuizOpenQuestionAnswerForVerificationResponse>> GetOpenQuestionsAnswer(
        string quizId, CancellationToken cancellationToken)
    {
        if (!AggregateId.TryParse(quizId, out var aggregateId))
            return BadRequest();

        var result = await Gate.DispatchQueryAsync<
            GetQuizOpenQuestionsAnswerForVerificationQuery,
            IReadOnlyCollection<QuizOpenQuestionAnswerForVerificationResponse>>(
            new GetQuizOpenQuestionsAnswerForVerificationQuery(aggregateId), cancellationToken);

        if (result.IsEmpty())
            return NotFound();

        return Ok(result);
    }

    [HttpPost("verify")]
    public async Task<IActionResult> Verify([FromBody] VerifyQuizRequest request, CancellationToken cancellationToken)
    {
        await Gate.DispatchCommandAsync<VerifyQuizRequest, VerifyQuizCommand>(request, cancellationToken);
        return Ok();
    }
}