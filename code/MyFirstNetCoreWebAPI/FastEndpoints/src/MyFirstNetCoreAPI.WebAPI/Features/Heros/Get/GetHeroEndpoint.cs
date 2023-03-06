using Commons.DTOs.Heros.Add;
using Commons.DTOs.Heros.Get;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace MyFirstNetCoreAPI.WebAPI.Features.Heros.Get;

[HttpGet("/hero/{id}")]
[AllowAnonymous]
public class GetHeroEndpoint : Endpoint<GetHeroRequest, GetHeroResponse>
{
    public override Task HandleAsync(GetHeroRequest request, CancellationToken ct)
    {
        var hero = new GetHeroResponse(request.Id, "Barry Allen", "The Flash");

        return SendOkAsync(hero);
    }
}
