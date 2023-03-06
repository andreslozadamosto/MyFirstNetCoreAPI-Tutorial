using Commons.Data;
using Commons.DTOs.Heros.Add;
using FluentValidation;
using MinimalApi.Endpoint.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IMarvelContext, MarvelContext>();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(AddHeroRequest));

builder.Services.AddEndpoints();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
} else
{
    app.UseExceptionHandler(
        x => x.Run(
            async ctx => await Results.Problem().ExecuteAsync(ctx)));
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();
