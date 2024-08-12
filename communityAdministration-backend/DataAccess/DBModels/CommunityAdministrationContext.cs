using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.DBModels
{
    public partial class CommunityAdministrationContext : DbContext
    {
        public CommunityAdministrationContext()
        {
        }

        public CommunityAdministrationContext(DbContextOptions<CommunityAdministrationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; } = null!;
        public virtual DbSet<CommunityAdministration> CommunityAdministrations { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseRegistered> CourseRegistereds { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Library> Libraries { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<ParticipantInActivity> ParticipantInActivities { get; set; } = null!;
        public virtual DbSet<PlayingCenter> PlayingCenters { get; set; } = null!;
        public virtual DbSet<UnitTimeOfLibrary> UnitTimeOfLibraries { get; set; } = null!;
        public virtual DbSet<UnitTimeOfPlayingCenter> UnitTimeOfPlayingCenters { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=CommunityAdministration;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.ToTable("Activity");

                entity.Property(e => e.ActivityName).HasMaxLength(50);

                entity.Property(e => e.BeginngTime)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Color).HasMaxLength(10);

                entity.Property(e => e.CommunityAdministrationId).HasMaxLength(15);

                entity.Property(e => e.Date)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Day)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.EndTime)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.EndTimeOfPreview).HasColumnType("date");

                entity.Property(e => e.Logo).HasMaxLength(200);

                entity.Property(e => e.MaxParticipants).HasColumnName("maxParticipants");

                entity.Property(e => e.TargetAudience).HasMaxLength(50);

                entity.HasOne(d => d.CommunityAdministration)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.CommunityAdministrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_CommunityAdministration");
            });

            modelBuilder.Entity<CommunityAdministration>(entity =>
            {
                entity.ToTable("CommunityAdministration");

                entity.Property(e => e.CommunityAdministrationId).HasMaxLength(15);

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Color)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Logo).HasMaxLength(1000);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.BeginngTime)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Color).HasMaxLength(10);

                entity.Property(e => e.CommunityAdministrationId).HasMaxLength(15);

                entity.Property(e => e.CourseName)
                    .HasMaxLength(100)
                    .HasColumnName("courseName");

                entity.Property(e => e.Day)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.EndTime)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.EndTimeOfPreview).HasColumnType("date");

                entity.Property(e => e.EndTimeOfRegister).HasColumnType("date");

                entity.Property(e => e.Logo).HasMaxLength(200);

                entity.Property(e => e.OperatorName).HasMaxLength(50);

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.TargetAudience).HasMaxLength(50);

                entity.HasOne(d => d.CommunityAdministration)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CommunityAdministrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_CommunityAdministration");
            });

            modelBuilder.Entity<CourseRegistered>(entity =>
            {
                entity.ToTable("CourseRegistered");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(9);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseRegistereds)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseRegistered_Course");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CourseRegistereds)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseRegistered_User");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Image");

                entity.Property(e => e.FileName).HasMaxLength(500);

                entity.Property(e => e.FilePath).HasMaxLength(500);
            });

            modelBuilder.Entity<Library>(entity =>
            {
                entity.ToTable("Library");

                entity.Property(e => e.CommunityAdministrationId).HasMaxLength(15);

                entity.HasOne(d => d.CommunityAdministration)
                    .WithMany(p => p.Libraries)
                    .HasForeignKey(d => d.CommunityAdministrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Library_CommunityAdministration");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.ActivityId).HasDefaultValueSql("((0))");

                entity.Property(e => e.CommunityAdministrationId)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CourseId).HasDefaultValueSql("((0))");

                entity.Property(e => e.CreationDateOfMessage).HasColumnType("date");

                entity.Property(e => e.EndTimeOfMessage).HasColumnType("date");

                entity.Property(e => e.LibraryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.MessageContent).HasMaxLength(500);

                entity.Property(e => e.PlayingCenterId).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<ParticipantInActivity>(entity =>
            {
                entity.HasKey(e => e.ParticipantId);

                entity.ToTable("ParticipantInActivity");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(9);

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ParticipantInActivities)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParticipantInActivity_Activity");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ParticipantInActivities)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParticipantInActivity_User");
            });

            modelBuilder.Entity<PlayingCenter>(entity =>
            {
                entity.ToTable("PlayingCenter");

                entity.Property(e => e.CommunityAdministrationId).HasMaxLength(15);

                entity.HasOne(d => d.CommunityAdministration)
                    .WithMany(p => p.PlayingCenters)
                    .HasForeignKey(d => d.CommunityAdministrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayingCenter_CommunityAdministration");
            });

            modelBuilder.Entity<UnitTimeOfLibrary>(entity =>
            {
                entity.HasKey(e => e.UnitTimeId);

                entity.ToTable("UnitTimeOfLibrary");

                entity.Property(e => e.BeginngTime).HasMaxLength(5);

                entity.Property(e => e.Day)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.EndTime).HasMaxLength(5);

                entity.Property(e => e.TargetAudience)
                    .HasMaxLength(50)
                    .HasColumnName("targetAudience");

                entity.HasOne(d => d.Library)
                    .WithMany(p => p.UnitTimeOfLibraries)
                    .HasForeignKey(d => d.LibraryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UnitTimeOfLibrary_Library");
            });

            modelBuilder.Entity<UnitTimeOfPlayingCenter>(entity =>
            {
                entity.HasKey(e => e.UnitTimeId);

                entity.ToTable("UnitTimeOfPlayingCenter");

                entity.Property(e => e.BeginningTime).HasMaxLength(5);

                entity.Property(e => e.Day)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.EndTime).HasMaxLength(5);

                entity.Property(e => e.OperatorName).HasMaxLength(50);

                entity.HasOne(d => d.PlayingCenter)
                    .WithMany(p => p.UnitTimeOfPlayingCenters)
                    .HasForeignKey(d => d.PlayingCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UnitTimeOfPlayingCenter_PlayingCenter");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasMaxLength(9);

                entity.Property(e => e.CommunityAdministrationId).HasMaxLength(15);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(16);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.CommunityAdministration)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CommunityAdministrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_CommunityAdministration");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
