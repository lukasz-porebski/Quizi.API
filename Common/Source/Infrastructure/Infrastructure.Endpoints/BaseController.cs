using Microsoft.AspNetCore.Mvc;

namespace Common.Infrastructure.Endpoints;

public class BaseController(IGate gate) : ControllerBase
{
    protected IGate Gate { get; } = gate;
}