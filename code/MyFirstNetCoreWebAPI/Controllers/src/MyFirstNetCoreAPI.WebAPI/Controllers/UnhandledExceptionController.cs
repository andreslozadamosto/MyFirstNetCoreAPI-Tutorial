using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstNetCoreAPI.WebAPI.Controllers;

[ApiController]
[Route("unhandled")]
[AllowAnonymous]
public class UnhandledExceptionController: ControllerBase
{
    [HttpGet("")]
    public Task<ActionResult> Get()
    {
        throw new ArgumentException("Unhandled Exception");
    }
}
