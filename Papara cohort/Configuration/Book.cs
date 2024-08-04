using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papara_cohort.Model;

namespace Papara_cohort.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasMaxLength(100000).IsRequired();
        builder.Property(x => x.PageCount).IsRequired(true).HasMaxLength(5);
        builder.HasIndex(x => x.Title).IsUnique(true);
        builder.Property(x => x.Title).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.PublishedDate).IsRequired(true);



    }
}
