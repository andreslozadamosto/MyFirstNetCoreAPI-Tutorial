using Commons.DTOs.Heros.Add;
using Commons.DTOs.Heros.Get;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.OpenApi.Validations.Rules;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace MyFirstNetCoreAPI.WebAPI.Controllers;

[ApiController]
[Route("hero")]
[AllowAnonymous]
public class HeroController: ControllerBase
{
    [HttpGet("/{id}", Name = "getHeroById")]
    //[SwaggerOperation("getHeroById")]
    public Task<ActionResult> GetByIdAsync(int id, [FromServices] GetHeroRequestValidator validator)
    {
        var validatorResult = validator.Validate(new GetHeroRequest(id));
        if (!validatorResult.IsValid) {
            return Task.FromResult<ActionResult>(BadRequest(new ValidationProblemDetails(validatorResult.ToDictionary())));
        }

        var hero = new GetHeroResponse(id, "Barry Allen", "The Flash");

        return Task.FromResult<ActionResult>(Ok(hero));
    }

    [HttpPost]
    public Task<ActionResult> AddHero(AddHeroRequest request, [FromServices] AddHeroRequestValidator validator)
    {
        var validatorResult = validator.Validate(request);
        if (!validatorResult.IsValid)
            return Task.FromResult<ActionResult>(BadRequest(new ValidationProblemDetails(validatorResult.ToDictionary())));

        var hero = new AddHeroResponse(1, request.Name, request.NickName);
        
        return Task.FromResult<ActionResult>(CreatedAtRoute(new { Id = hero.Id }, hero));
    }
}
