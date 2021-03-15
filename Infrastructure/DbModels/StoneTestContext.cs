using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StoneTest.Infrastructure.DbModels
{
    public partial class StoneTestContext : DbContext
    {
        public StoneTestContext()
        {
        }

        public StoneTestContext(DbContextOptions<StoneTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<CurrencyRate> CurrencyRate { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: убрать строку подключения
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=KOMP777\\SQLEXPRESS;Database=StoneTest;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.CharCode)
                    .HasColumnName("char_code")
                    .HasMaxLength(100);

                entity.Property(e => e.EngName)
                    .HasColumnName("eng_name")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Nominal).HasColumnName("nominal");

                entity.Property(e => e.NumCode)
                    .HasColumnName("num_code")
                    .HasMaxLength(100);

                entity.Property(e => e.ParentCode)
                    .HasColumnName("parent_code")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CurrencyRate>(entity =>
            {
                entity.HasKey(e => new { e.Date, e.CharCode });

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.CharCode)
                    .HasColumnName("char_code")
                    .HasMaxLength(100);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Nominal)
                    .HasColumnName("nominal")
                    .HasMaxLength(100);

                entity.Property(e => e.NumCode)
                    .HasColumnName("num_code")
                    .HasMaxLength(100);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("decimal(20, 4)");
            });
        }
    }
}
