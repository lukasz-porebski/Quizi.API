using Application.Contracts.Modules.Users.Commands;
using Common.Infrastructure.Endpoints;
using Microsoft.AspNetCore.Mvc;
using PublishedLanguage.Modules.Users.Requests;

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
}