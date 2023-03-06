using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace MyFirstNetCoreAPI.WebAPI.Features.Home;

[HttpGet("/")]
[AllowAnonymous]
public class HomeEndpoint : Endpoint<EmptyRequest,string>
{
    public override Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        return SendAsync("Hello World from FastEndpoints");
    }
}
