using Microsoft.AspNetCore.Http.HttpResults;
using MinimalApi.Endpoint;
using MyFirstNetCoreAPI.WebAPI.Filters;
using Commons.DTOs.Heros.Get;

namespace MyFirstNetCoreAPI.WebAPI.HerosEnpoints.Get;

public class GetHeroEndpoint : IEndpoint<Results<Ok<GetHeroResponse>, NotFound>, GetHeroRequest>
{
    public void AddRoute(IEndpointRouteBuilder app)
    {
        app
            .MapGet("/hero/{id}", ([AsParameters] GetHeroRequest request) => HandleAsync(request))
            .WithName("getHeroById")
            .AddEndpointFilter<ValidationFilter<GetHeroRequest>>()
            .WithOpenApi();
    }

    public async Task<Results<Ok<GetHeroResponse>, NotFound>> HandleAsync(GetHeroRequest request)
    {
        var hero = new GetHeroResponse(request.Id, "Barry Allen", "The Flash");

        var result = TypedResults.Ok<GetHeroResponse>(hero);

        return await Task.FromResult(result);
    }
}
