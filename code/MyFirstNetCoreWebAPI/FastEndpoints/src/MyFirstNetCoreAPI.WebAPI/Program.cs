using Commons.DTOs.Heros.Add;
using FastEndpoints;
using FastEndpoints.Swagger;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssemblyContaining(typeof(AddHeroRequest));
builder.Services.AddFastEndpoints(o => { o.IncludeAbstractValidators = true; });
builder.Services.AddSwaggerDoc();


var app = builder.Build();
app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(c => c.ConfigureDefaults());

app.Run();
