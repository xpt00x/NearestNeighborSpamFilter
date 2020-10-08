using System;
using Microsoft.EntityFrameworkCore;
using NearestNeighborsSpamFilter.App.Infrastructure.Db.DTO;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;

namespace NearestNeighborsSpamFilter.App.Infrastructure.Db
{
    public partial class NnDbContext : DbContext
    {
        public NnDbContext()
        {
        }

        public NnDbContext(DbContextOptions<NnDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dictionary> Dictionary { get; set; }
        public virtual DbSet<Emails> Emails { get; set; }
        public virtual DbSet<ModelDataPoints> ModelDataPoints { get; set; }
        public virtual DbSet<TrainingPoints> TrainingPoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["NNSpamFilterConnection"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dictionary>(entity =>
            {
                entity.Property(e => e.DateImported)
                    .HasColumnType("datetime2(3)")
                    .HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime2(3)");

                entity.Property(e => e.Word)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Emails>(entity =>
            {
                entity.Property(e => e.Body).IsUnicode(false);

                entity.Property(e => e.DateImported)
                    .HasColumnType("datetime2(3)")
                    .HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime2(3)");
            });

            modelBuilder.Entity<ModelDataPoints>(entity =>
            {
                entity.HasOne(d => d.IdWordNavigation)
                    .WithMany(p => p.ModelDataPoints)
                    .HasForeignKey(d => d.IdWord)
                    .HasConstraintName("FK_ModelDataPoints_Dictionary");
            });

            modelBuilder.Entity<TrainingPoints>(entity =>
            {
                entity.HasOne(d => d.IdWordNavigation)
                    .WithMany(p => p.TrainingPoints)
                    .HasForeignKey(d => d.IdWord)
                    .HasConstraintName("FK_TrainingPoints_Dictionary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
