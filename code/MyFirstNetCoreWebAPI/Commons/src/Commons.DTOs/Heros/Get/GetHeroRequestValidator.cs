using FluentValidation;

namespace Commons.DTOs.Heros.Get;

public sealed class GetHeroRequestValidator : AbstractValidator<GetHeroRequest>
{
    public GetHeroRequestValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0);
    }
}
