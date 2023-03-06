using Commons.DTOs.Heros.Add;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using MyFirstNetCoreAPI.WebAPI.Features.Heros.Get;

namespace MyFirstNetCoreAPI.WebAPI.Features.Heros.Add;

[HttpPost("/hero")]
[AllowAnonymous]
public class AddHeroEndpoint : Endpoint<AddHeroRequest, AddHeroResponse>
{
    public override Task HandleAsync(AddHeroRequest request, CancellationToken ct)
    {
        var hero = new AddHeroResponse(1, request.Name, request.NickName);

        return SendCreatedAtAsync<GetHeroEndpoint>(new { id = hero.Id }, hero);
    }
}