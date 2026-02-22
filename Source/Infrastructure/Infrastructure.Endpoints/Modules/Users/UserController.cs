using Application.Contracts.Modules.Users.Commands;
using Application.Contracts.Modules.Users.Dtos;
using Application.Contracts.Modules.Users.Queries;
using Common.Application.Contracts.ReadModel;
using Common.Identity.Contracts.Attributes;
using Common.Infrastructure.Endpoints;
using Common.Infrastructure.Endpoints.Requests;
using Common.Infrastructure.Endpoints.Responses;
using Infrastructure.Endpoints.Modules.Users.Requests;
using Infrastructure.Endpoints.Modules.Users.Responses;
using Infrastructure.Endpoints.Shared;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("list"), Permission(AppPermissions.UsersList)]
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