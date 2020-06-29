using Arts.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.DataAccess.Configurations
{
    public class PieceOfArtConfiguration : IEntityTypeConfiguration<PieceOfArt>
    {
        public void Configure(EntityTypeBuilder<PieceOfArt> builder)
        {
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(a => a.Description)
                .HasMaxLength(255);

            builder.HasMany(x => x.Comments)
                    .WithOne(c => c.PieceOfArt)
                    .HasForeignKey(x => x.PieceOfArtId)
                    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
