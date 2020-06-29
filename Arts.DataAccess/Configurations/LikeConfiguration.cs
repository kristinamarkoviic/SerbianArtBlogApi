using Arts.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.DataAccess.Configurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.PieceOfArtId)
                .IsRequired();

            builder.Property(x => x.Status).HasColumnType("bigint");
        }
    }
}
