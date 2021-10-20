using System;
using ConferenceSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ConferenceSystem.Data
{
    public partial class AfterhillsContext : DbContext
    {
        public AfterhillsContext(DbContextOptions<AfterhillsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Conference> Conferences { get; set; }
        public virtual DbSet<ConferenceXattendee> ConferenceXattendees { get; set; }
        public virtual DbSet<DictionaryStatus> DictionaryStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Conference>(entity =>
            {
                entity.ToTable("Conference");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.OrganizerEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<ConferenceXattendee>(entity =>
            {
                entity.ToTable("ConferenceXAttendee");

                entity.Property(e => e.AttendeeEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Conference)
                    .WithMany(p => p.ConferenceXattendees)
                    .HasForeignKey(d => d.ConferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConferenceXAttendee_Conference");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ConferenceXattendees)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConferenceXAttendee_DictionaryStatus");
            });

            modelBuilder.Entity<DictionaryStatus>(entity =>
            {
                entity.ToTable("DictionaryStatus");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
