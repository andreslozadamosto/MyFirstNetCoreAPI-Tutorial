using Commons.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Commons.Data;

public class MarvelContext : DbContext, IMarvelContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "MarvelDB");
    }

    public DbSet<SupeHero> SuperHeros { get; set; }
}
