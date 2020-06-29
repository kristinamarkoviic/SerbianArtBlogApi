using Arts.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.DataAccess.Configurations
{
    public class UsersUseCasesConfiguration : IEntityTypeConfiguration<UserUseCases>
    {
        public void Configure(EntityTypeBuilder<UserUseCases> builder)
        {
            builder.Property(x => x.UseCaseId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}
