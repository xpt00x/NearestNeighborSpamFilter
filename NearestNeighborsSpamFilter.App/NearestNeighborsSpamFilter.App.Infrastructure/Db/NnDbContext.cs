using System;
using Microsoft.EntityFrameworkCore;
using NearestNeighborsSpamFilter.App.Infrastructure.Db.DTO;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace NearestNeighborsSpamFilter.App.Infrastructure.Db
{
    public partial class NnDbContext : DbContext
    {
        private string connectionString { get; set; }
        public NnDbContext()
        {
        }

        public NnDbContext(DbContextOptions<NnDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BowDictionary> BowDictionary { get; set; }
        public virtual DbSet<Emails> Emails { get; set; }
        public virtual DbSet<DataPoints> DataPoints { get; set; }
        public virtual DbSet<TrainingPoints> TrainingPoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BowDictionary>(entity =>
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

            modelBuilder.Entity<DataPoints>(entity =>
            {
                entity.HasOne(d => d.IdWordNavigation)
                    .WithMany(p => p.DataPoints)
                    .HasForeignKey(d => d.IdWord)
                    .HasConstraintName("FK_DataPoints_BowDictionary");
            });

            modelBuilder.Entity<TrainingPoints>(entity =>
            {
                entity.HasOne(d => d.IdWordNavigation)
                    .WithMany(p => p.TrainingPoints)
                    .HasForeignKey(d => d.IdWord)
                    .HasConstraintName("FK_TrainingPoints_BowDictionary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
