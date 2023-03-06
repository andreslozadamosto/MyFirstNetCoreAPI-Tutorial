using FluentValidation;

namespace Commons.DTOs.Heros.Add;

public sealed class AddHeroRequestValidator : AbstractValidator<AddHeroRequest>
{
    public AddHeroRequestValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.NickName).NotNull().NotEmpty();
    }
}
