using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Endpoint;

namespace MyFirstNetCoreAPI.WebAPI.HomeEndopoints;

public class HomeEndpoint : IEndpoint<Ok<string>>
{
    public void AddRoute(IEndpointRouteBuilder app)
    {
        app
            .MapGet("/", () => HandleAsync())
            .WithOpenApi();
    }

    public Task<Ok<string>> HandleAsync()
    {
        var result = TypedResults.Ok<string>("Hello world from Minimal APIs");
        return Task.FromResult<Ok<string>>(result);
        
    }
}
