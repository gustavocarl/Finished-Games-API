using FinishedGamesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinishedGamesAPI.Data.Mappings;

public class GameMap : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.ToTable("FinishedGames");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired(true)
            .HasMaxLength(160)
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.Description)
            .IsRequired(true)
            .HasMaxLength(500)
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.Platform)
            .IsRequired(true)
            .HasMaxLength(50)
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.Genre)
            .IsRequired(true)
            .HasMaxLength(50)
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.Grade)
            .IsRequired(true)
            .HasMaxLength(2)
            .HasColumnType("NVARCHAR");
    }
}