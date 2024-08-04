using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papara_cohort.Model;

namespace Papara_cohort.Configuration;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasMaxLength(100000).IsRequired();
        builder.HasIndex(x => x.Name).IsUnique(true);
        builder.Property(x => x.Name).IsRequired(true).HasMaxLength(50);


        builder.HasMany(x => x.Books).WithOne(x => x.Genre).HasForeignKey(x => x.GenreName).HasPrincipalKey(x => x.Name).OnDelete(DeleteBehavior.Cascade);


    }
}
