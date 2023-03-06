using Commons.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Commons.Data;
public interface IMarvelContext
{
    DbSet<SupeHero> SuperHeros { get; set; }
}
