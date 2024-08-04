using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papara_cohort.Model;

namespace Papara_cohort.Configuration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasMaxLength(100000).IsRequired();
        builder.HasIndex(x => x.Name).IsUnique(true);
        builder.Property(x => x.Name).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.DateOfBirth).IsRequired(true);

        builder.HasMany(x => x.Books).WithOne(x => x.Author).HasForeignKey(x => x.AuthorName).HasPrincipalKey(x => x.Name).OnDelete(DeleteBehavior.Cascade);


    }
}
