using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstNetCoreAPI.WebAPI.Controllers;

[ApiController]
[AllowAnonymous]
public class ErrorController: ControllerBase
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("/error")]
    public IActionResult HandleError() => Problem();
}
