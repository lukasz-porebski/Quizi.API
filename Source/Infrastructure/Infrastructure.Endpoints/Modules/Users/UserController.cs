using Application.Contracts.Modules.Users.Commands;
using Application.Contracts.Modules.Users.Dtos;
using Application.Contracts.Modules.Users.Queries;
using Common.Application.Contracts.ReadModel;
using Common.Identity.Contracts.Attributes;
using Common.Infrastructure.Endpoints;
using Common.PublishedLanguage.Requests;
using Common.PublishedLanguage.Responses;
using Infrastructure.Endpoints.Shared;
using Microsoft.AspNetCore.Mvc;
using PublishedLanguage.Modules.Users.Requests;
using PublishedLanguage.Modules.Users.Responses;

namespace Infrastructure.Endpoints.Modules.Users;

[Route("users")]
public class UserController(IGate gate) : BaseController(gate)
{
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        await Gate.DispatchCommandAsync<CreateUserRequest, CreateUserCommand>(request, cancellationToken);
        return Ok();
    }

    [HttpGet("list"), Permission(Permissions.UsersList)]
    public async Task<ActionResult<PaginatedListDto<UsersListItemDto>>> GetList(
        [FromQuery] PaginationRequest request, CancellationToken cancellationToken)
    {
        var result = await Gate.DispatchQueryAsync<
            PaginationRequest,
            GetUsersQuery,
            PaginatedListDto<UsersListItemDto>,
            PaginatedListResponse<UsersListItemResponse>>(
            request, cancellationToken);
        return Ok(result);
    }
}