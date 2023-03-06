using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstNetCoreAPI.WebAPI.Controllers;

[ApiController]
[Route("")]
[AllowAnonymous]
public class HomeController: ControllerBase
{
    [HttpGet()]
    public Task<ActionResult> Get()
    {
        return Task.FromResult<ActionResult>(Ok("Hello from ASP.Net Core Web API"));
    }
}

