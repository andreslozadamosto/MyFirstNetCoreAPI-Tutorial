
namespace Commons.DTOs.Heros.Add;

public sealed record AddHeroRequest(string Name, string NickName)
{
    public AddHeroRequest() : this(string.Empty, string.Empty) { }
}
