using Commons.DTOs.Heros.Add;
using Microsoft.AspNetCore.Http.HttpResults;
using MinimalApi.Endpoint;
using MyFirstNetCoreAPI.WebAPI.Filters;

namespace MyFirstNetCoreAPI.WebAPI.HerosEnpoints.Add;

public class AddHeroEndpoint : IEndpoint<Results<CreatedAtRoute<AddHeroResponse>, ValidationProblem>, AddHeroRequest>
{
    public void AddRoute(IEndpointRouteBuilder app)
    {
        app
            .MapPost("/hero", (AddHeroRequest request) => HandleAsync(request))
            .AddEndpointFilter<ValidationFilter<AddHeroRequest>>()
            .WithOpenApi();
    }

    public async Task<Results<CreatedAtRoute<AddHeroResponse>, ValidationProblem>> HandleAsync(AddHeroRequest request)
    {
        var hero = new AddHeroResponse(1, request.Name, request.NickName);
        
        var result = TypedResults.CreatedAtRoute<AddHeroResponse>(
            hero,
            "getHeroById",
            new { id = hero.Id });

        return await Task.FromResult(result);
    }
}
