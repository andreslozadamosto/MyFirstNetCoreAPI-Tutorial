using Microsoft.AspNetCore.Mvc;
using MinimalApi.Endpoint;

namespace MyFirstNetCoreAPI.WebAPI.UnhandledExceptionEndpoints;

public class UnhandledExceptionEndpoint : IEndpoint<ObjectResult>
{
    public void AddRoute(IEndpointRouteBuilder app)
    {
        app
            .MapGet("/unhandled", () => HandleAsync())
            .WithOpenApi();
    }

    public Task<ObjectResult> HandleAsync()
    {
        throw new InvalidOperationException("Unhandled Exception");
    }
}