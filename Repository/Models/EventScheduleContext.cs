using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class EventScheduleContext : DbContext
{
    public EventScheduleContext()
    {
    }

    public EventScheduleContext(DbContextOptions<EventScheduleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAdmin> TblAdmins { get; set; }

    public virtual DbSet<TblCategory> TblCategories { get; set; }

    public virtual DbSet<TblEvent> TblEvents { get; set; }

    public virtual DbSet<TblEventParticipated> TblEventParticipateds { get; set; }

    public virtual DbSet<TblFeedback> TblFeedbacks { get; set; }

    public virtual DbSet<TblImage> TblImages { get; set; }

    public virtual DbSet<TblLocation> TblLocations { get; set; }

    public virtual DbSet<TblPayment> TblPayments { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblVideo> TblVideos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server =(local); database=EventSchedule; uid=sa;pwd=12345678; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAdmin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__tblClub__BCAD3DD90EA330E9");

            entity.ToTable("tblAdmin");

            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.AdminEmail)
                .HasMaxLength(100)
                .HasColumnName("admin_email");
            entity.Property(e => e.AdminName)
                .HasMaxLength(100)
                .HasColumnName("admin_name");
            entity.Property(e => e.AdminPassword)
                .HasMaxLength(100)
                .HasColumnName("admin_password");
            entity.Property(e => e.AdminPhone)
                .HasMaxLength(10)
                .HasColumnName("admin_phone");
            entity.Property(e => e.AdminRole)
                .HasMaxLength(50)
                .HasColumnName("admin_role");
            entity.Property(e => e.AdminStatus).HasColumnName("admin_status");
            entity.Property(e => e.ImageUrl).HasColumnName("image_url");
        });

        modelBuilder.Entity<TblCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__tblCateg__D54EE9B4014935CB");

            entity.ToTable("tblCategory");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<TblEvent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__tblEvent__2370F7270519C6AF");

            entity.ToTable("tblEvent");

            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.EventContent).HasColumnName("event_content");
            entity.Property(e => e.EventEnd)
                .HasColumnType("datetime")
                .HasColumnName("event_end");
            entity.Property(e => e.EventName)
                .HasMaxLength(50)
                .HasColumnName("event_name");
            entity.Property(e => e.EventStart)
                .HasColumnType("datetime")
                .HasColumnName("event_start");
            entity.Property(e => e.EventStatus).HasColumnName("event_status");
            entity.Property(e => e.LocationId).HasColumnName("location_id");

            entity.HasOne(d => d.Admin).WithMany(p => p.TblEvents)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_tblEvent_tblAdmin");

            entity.HasOne(d => d.Category).WithMany(p => p.TblEvents)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_tblEvent_tblCategory");

            entity.HasOne(d => d.Location).WithMany(p => p.TblEvents)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_tblEvent_tblLocation");
        });

        modelBuilder.Entity<TblEventParticipated>(entity =>
        {
            entity.HasKey(e => new { e.EventId, e.UsersId }).HasName("PK__tblEvent__8DDA8A3308EA5793");

            entity.ToTable("tblEventParticipated");

            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.UsersId).HasColumnName("users_id");
            entity.Property(e => e.DateParticipated)
                .HasColumnType("datetime")
                .HasColumnName("date_participated");
            entity.Property(e => e.PaymentStatus).HasColumnName("payment_status");
            entity.Property(e => e.UsersStatus).HasColumnName("users_status");

            entity.HasOne(d => d.Event).WithMany(p => p.TblEventParticipateds)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK_tblEventParticipated_tblEvent");

            entity.HasOne(d => d.Users).WithMany(p => p.TblEventParticipateds)
                .HasForeignKey(d => d.UsersId)
                .HasConstraintName("FK_tblEventParticipated_tblUser");
        });

        modelBuilder.Entity<TblFeedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__tblFeedb__7A6B2B8C0CBAE877");

            entity.ToTable("tblFeedback");

            entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("date")
                .HasColumnName("created_time");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.UsersId).HasColumnName("users_id");

            entity.HasOne(d => d.TblEventParticipated).WithMany(p => p.TblFeedbacks)
                .HasForeignKey(d => new { d.EventId, d.UsersId })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_tblFeedback_tblEventParticipated");
        });

        modelBuilder.Entity<TblImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__tblImage__DC9AC955108B795B");

            entity.ToTable("tblImage");

            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.ImageName)
                .HasMaxLength(50)
                .HasColumnName("image_name");
            entity.Property(e => e.ImageUrl).HasColumnName("image_url");

            entity.HasOne(d => d.Event).WithMany(p => p.TblImages)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_tblImage_tblEvent");
        });

        modelBuilder.Entity<TblLocation>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__tblLocat__771831EA145C0A3F");

            entity.ToTable("tblLocation");

            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.LocationDetail).HasColumnName("location_detail");
            entity.Property(e => e.LocationStatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("location_status");
        });

        modelBuilder.Entity<TblPayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__tblPayme__ED1FC9EA182C9B23");

            entity.ToTable("tblPayment");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.PaymentDetail).HasColumnName("payment_detail");
            entity.Property(e => e.PaymentFee).HasColumnName("payment_fee");
            entity.Property(e => e.PaymentUrl).HasColumnName("payment_url");

            entity.HasOne(d => d.Event).WithMany(p => p.TblPayments)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_tblPayment_tblEvent");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UsersId).HasName("PK__tblUser__EAA7D14B1BFD2C07");

            entity.ToTable("tblUser");

            entity.Property(e => e.UsersId).HasColumnName("users_id");
            entity.Property(e => e.UsersAddress)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("users_address");
            entity.Property(e => e.UsersEmail)
                .HasMaxLength(100)
                .HasColumnName("users_email");
            entity.Property(e => e.UsersName)
                .HasMaxLength(50)
                .HasColumnName("users_name");
            entity.Property(e => e.UsersPassword)
                .HasMaxLength(50)
                .HasColumnName("users_password");
            entity.Property(e => e.UsersPhone)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("users_phone");
        });

        modelBuilder.Entity<TblVideo>(entity =>
        {
            entity.HasKey(e => e.VideoId).HasName("PK__tblVideo__E8F11E1007020F21");

            entity.ToTable("tblVideo");

            entity.Property(e => e.VideoId).HasColumnName("video_id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.VideoName)
                .HasMaxLength(50)
                .HasColumnName("video_name");
            entity.Property(e => e.VideoUrl).HasColumnName("video_url");

            entity.HasOne(d => d.Event).WithMany(p => p.TblVideos)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_tblVideo_tblEvent");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
