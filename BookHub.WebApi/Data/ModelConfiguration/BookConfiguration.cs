using BookHub.WebApi.Entities;
using BookHub.WebApi.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookHub.WebApi.Data.ModelConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Title)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(b => b.Author)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(b => b.ISBN)
                .HasColumnType("varchar")
                .HasMaxLength(20);

            builder.HasAlternateKey(r => r.ISBN);

            builder.Property(b => b.PublishedYear)
                .HasColumnType("int");

            builder.Property(r => r.Price)
                .HasPrecision(10, 2)
                .HasDefaultValue(0.00m)
                .IsRequired();

            builder.Property(b => b.Genre)
                .HasConversion<string>()
                .HasDefaultValue(Genre.History);
        }
    }
}
