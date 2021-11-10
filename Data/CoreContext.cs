using System;
using Bingo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bingo.data
{
    public partial class CoreContext : DbContext
    {
        public CoreContext() { }

        public CoreContext(DbContextOptions<CoreContext> options) : base(options) { }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=ec2-34-228-100-83.compute-1.amazonaws.com;Port=5432;Username=d97j2hdfm9git9;Password=cdd9758316fa8999c06cc10840046b3f59f8c681e04571cac28e229c4c0d7946;Database=d97j2hdfm9git9; Pooling=true; SSL Mode=Require;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
           {
               entity.HasKey(e=>e.Id);
           });
            modelBuilder.Entity<Game>(entity =>
           {
               entity.HasKey(e=>e.Id);
           });
            modelBuilder.Entity<Item>(entity =>
           {
               entity.HasKey(e=>e.Id);
           });
            modelBuilder.Entity<Admin>(entity =>
           {
               entity.HasKey(e=>e.Id);
               entity.HasOne(e=>e.Game);
               entity.HasOne(e=>e.User);
           });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
