using Application.Contracts.Modules.Quizzes.Commands;
using Application.Contracts.Modules.Quizzes.Dtos;
using Application.Contracts.Modules.Quizzes.Queries;
using Application.Contracts.Modules.SharedQuizzes.Commands;
using Common.Application.Contracts.ReadModel;
using Common.Domain.Extensions;
using Common.Infrastructure.Endpoints;
using Microsoft.AspNetCore.Mvc;
using PublishedLanguage.Modules.Quizzes.Requests;
using PublishedLanguage.Shared.Requests;

namespace Infrastructure.Endpoints.Modules.Quizzes;

[Route("quizzes")]
public class QuizController(IGate gate) : BaseController(gate)
{
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateQuizRequest request, CancellationToken cancellationToken)
    {
        await Gate.DispatchCommandAsync<CreateQuizRequest, CreateQuizCommand>(request, cancellationToken);
        return Ok();
    }

    [HttpPatch("update")]
    public async Task<IActionResult> Update([FromBody] UpdateQuizRequest request, CancellationToken cancellationToken)
    {
        await Gate.DispatchCommandAsync<UpdateQuizRequest, UpdateQuizCommand>(request, cancellationToken);
        return Ok();
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> Delete([FromQuery] string id, CancellationToken cancellationToken)
    {
        await Gate.DispatchCommandAsync(new RemoveQuizCommand(id.ToAggregateId()), cancellationToken);
        return Ok();
    }

    [HttpPut("add-user")]
    public async Task<IActionResult> AddUser([FromBody] AddQuizUserRequest request, CancellationToken cancellationToken)
    {
        await Gate.DispatchCommandAsync<AddQuizUserRequest, AddQuizUserCommand>(request, cancellationToken);
        return Ok();
    }

    [HttpPatch("remove-user")]
    public async Task<IActionResult> RemoveUser([FromBody] RemoveQuizUserRequest request, CancellationToken cancellationToken)
    {
        await Gate.DispatchCommandAsync<RemoveQuizUserRequest, RemoveQuizUserCommand>(request, cancellationToken);
        return Ok();
    }

    [HttpGet("list")]
    public async Task<ActionResult<PaginatedListDto<QuizzesListItemDto>>> GetList(
        PaginationRequest request, CancellationToken cancellationToken)
    {
        var result = await Gate.DispatchQueryAsync<
            PaginationRequest,
            GetQuizzesQuery,
            PaginatedListDto<QuizzesListItemDto>,
            PaginatedListDto<QuizzesListItemDto>>(
            request, cancellationToken);
        return Ok(result);
    }
}