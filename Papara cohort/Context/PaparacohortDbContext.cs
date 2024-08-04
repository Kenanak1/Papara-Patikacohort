using Microsoft.EntityFrameworkCore;
using Papara_cohort.Configuration;
namespace Papara_cohort.Context;

public class PaparacohortDbContext : DbContext
{
    public PaparacohortDbContext(DbContextOptions<PaparacohortDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
    }
}
