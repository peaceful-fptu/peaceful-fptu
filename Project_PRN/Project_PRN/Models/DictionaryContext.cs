using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Project_PRN.Models
{
    public partial class DictionaryContext : DbContext
    {
        public DictionaryContext()
        {
        }

        public DictionaryContext(DbContextOptions<DictionaryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DictionaryEnvn> DictionaryEnvns { get; set; } = null!;
        public virtual DbSet<DictionaryVnen> DictionaryVnens { get; set; } = null!;
        public virtual DbSet<WorkTypeEnvn> WorkTypeEnvns { get; set; } = null!;
        public virtual DbSet<WorkTypeVnen> WorkTypeVnens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DictionaryEnvn>(entity =>
            {
                entity.HasKey(e => e.WordId);

                entity.ToTable("DictionaryENVN");

                entity.Property(e => e.WordId).HasColumnName("wordID");

                entity.Property(e => e.Meaning).HasColumnName("meaning");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Word)
                    .HasMaxLength(50)
                    .HasColumnName("word");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.DictionaryEnvns)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DictionaryENVN_workTypeENVN");
            });

            modelBuilder.Entity<DictionaryVnen>(entity =>
            {
                entity.HasKey(e => e.WordId);

                entity.ToTable("DictionaryVNEN");

                entity.Property(e => e.WordId)
                    .ValueGeneratedNever()
                    .HasColumnName("wordID");

                entity.Property(e => e.Meaning).HasColumnName("meaning");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Word)
                    .HasMaxLength(50)
                    .HasColumnName("word");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.DictionaryVnens)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DictionaryVNEN_workTypeVNEN");
            });

            modelBuilder.Entity<WorkTypeEnvn>(entity =>
            {
                entity.ToTable("workTypeENVN");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.WordType)
                    .HasMaxLength(50)
                    .HasColumnName("wordType");
            });

            modelBuilder.Entity<WorkTypeVnen>(entity =>
            {
                entity.ToTable("workTypeVNEN");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.WordType)
                    .HasMaxLength(50)
                    .HasColumnName("wordType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
