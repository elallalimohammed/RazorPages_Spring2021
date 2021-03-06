﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using System;

#nullable disable

namespace EventMaker_EFChapter2.Models
{
    public partial class EventMakerDBContext : DbContext
    {
        public EventMakerDBContext()
        {
        }
        public EventMakerDBContext(DbContextOptions<EventMakerDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EventMakerDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Country__A25C5AA6FB268224");

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.CountryCode).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Event_Country");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}