using Commons.DTOs.Heros.Add;
using FluentValidation.TestHelper;

namespace Commons.DTOs.Tests.Heros.Add;

public class AddHeroRequestValidatorTests
{
    [Theory]
    [InlineData("", "")]
    [InlineData("", "The Flash")]
    [InlineData("Barry Allen", "")]
    [InlineData(null, "The Flah")]
    [InlineData("Barry Allen", null)]
    [InlineData(null, null)]
    public void validator_WhenRequestIsNotValid_ShouldThrow(string name, string nickName)
    {
        // Arrange
        var sut = new AddHeroRequestValidator();
        var request = new AddHeroRequest(name, nickName);

        // Act
        var validationResult = sut.TestValidate(request);

        // Assert
        validationResult.ShouldHaveAnyValidationError();
    }

    [Fact]
    public void validator_WhenRequestIsValid_ShouldThrow()
    {
        // Arrange
        var sut = new AddHeroRequestValidator();
        var request = new AddHeroRequest("Burce Wayne", "Batman");

        // Act
        var validationResult = sut.TestValidate(request);

        // Assert
        validationResult.ShouldNotHaveAnyValidationErrors();
    }
}
