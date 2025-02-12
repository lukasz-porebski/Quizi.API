using Application.Contracts.Modules.QuizzesVerification.Commands;
using Common.Infrastructure.Endpoints;
using Microsoft.AspNetCore.Mvc;
using PublishedLanguage.Modules.QuizResults.Requests;

namespace Infrastructure.Endpoints.Modules.QuizResults;

[Route("quiz-results")]
public class QuizResultController(IGate gate) : BaseController(gate)
{
    [HttpPost("verify")]
    public async Task<IActionResult> Verify([FromBody] VerifyQuizRequest request, CancellationToken cancellationToken)
    {
        await Gate.DispatchCommandAsync<VerifyQuizRequest, VerifyQuizCommand>(request, cancellationToken);
        return Ok();
    }
}