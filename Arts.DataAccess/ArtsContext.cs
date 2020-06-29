using Arts.DataAccess.Configurations;
using Arts.Domain.Configurations;
using Arts.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.DataAccess
{
    public class ArtsContext: DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UsersUseCasesConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new PieceOfArtConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());

            
            modelBuilder.Entity<Country>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<PieceOfArt>().HasQueryFilter(pp => !pp.IsDeleted);
            modelBuilder.Entity<Comment>().HasQueryFilter(com => !com.IsDeleted);
            modelBuilder.Entity<Like>().HasQueryFilter(com => !com.IsDeleted);
        }


        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.CreatedAt = DateTime.Now;
                            e.IsDeleted = false;
                            e.ModifiedAt = null;
                            e.DeletedAt = null;
                            break;
                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.Now;
                            break;
                    }
                }
            }
            return base.SaveChanges();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-VF7TH11\SQLEXPRESS; Initial Catalog=arts; Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<UserUseCases> UserUseCases { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PieceOfArt> PieceOfArts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Like> Likes { get; set; }
    }
}
