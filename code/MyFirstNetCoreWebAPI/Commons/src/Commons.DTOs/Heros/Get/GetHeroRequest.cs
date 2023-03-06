namespace Commons.DTOs.Heros.Get;

public sealed record GetHeroRequest(int Id)
{
    public GetHeroRequest() : this (default(int)) { }
}
