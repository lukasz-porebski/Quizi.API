using Application.Contracts.Modules.QuizzesVerification.Commands;
using Application.Contracts.Modules.QuizzesVerification.Data;
using Application.Contracts.Modules.QuizzesVerification.Dtos;
using Application.Contracts.Modules.QuizzesVerification.Queries;
using AutoMapper;
using Infrastructure.Endpoints.Modules.QuizzesVerification.Requests;
using Infrastructure.Endpoints.Modules.QuizzesVerification.Responses;
using LP.Common.Domain.ValueObjects;
using LP.Common.Infrastructure.Endpoints;
using LP.Common.Shared.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Endpoints.Modules.QuizzesVerification;

[Route("quizzes-verification"), Authorize]
public class QuizVerificationController(IGate gate, IMapper mapper) : BaseController(gate)
{
    [HttpGet("quiz-to-run/{id}")]
    public async Task<ActionResult<QuizToRunResponse>> GetQuizToRun(string id, CancellationToken cancellationToken)
    {
        if (!AggregateId.TryParse(id, out var aggregateId))
            return BadRequest();

        var result = await Gate.DispatchQueryAsync<GetQuizToRunQuery, QuizToRunData?, QuizToRunResponse?>(
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
            IReadOnlyCollection<QuizOpenQuestionAnswerForVerificationDto>,
            IReadOnlyCollection<QuizOpenQuestionAnswerForVerificationResponse>>(
            new GetQuizOpenQuestionsAnswerForVerificationQuery(aggregateId), cancellationToken);

        if (result.IsEmpty())
            return NotFound();

        return Ok(result);
    }

    [HttpPost("verify")]
    public async Task<ActionResult<string>> Verify([FromBody] VerifyQuizRequest request, CancellationToken cancellationToken)
    {
        var command = mapper.Map<VerifyQuizRequest, VerifyQuizCommand>(request);
        await Gate.DispatchCommandAsync(command, cancellationToken);
        return Ok(command.QuizResultId.ToString());
    }
}