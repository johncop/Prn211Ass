﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Models;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(EventScheduleContext))]
    partial class EventScheduleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Repository.Models.TblAdmin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("admin_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("AdminEmail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("admin_email");

                    b.Property<string>("AdminName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("admin_name");

                    b.Property<string>("AdminPassword")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("admin_password");

                    b.Property<string>("AdminPhone")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("admin_phone");

                    b.Property<string>("AdminRole")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("admin_role");

                    b.Property<bool?>("AdminStatus")
                        .HasColumnType("bit")
                        .HasColumnName("admin_status");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image_url");

                    b.HasKey("AdminId")
                        .HasName("PK__tblClub__BCAD3DD90EA330E9");

                    b.ToTable("tblAdmin", (string)null);
                });

            modelBuilder.Entity("Repository.Models.TblCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("category_name");

                    b.HasKey("CategoryId")
                        .HasName("PK__tblCateg__D54EE9B4014935CB");

                    b.ToTable("tblCategory", (string)null);
                });

            modelBuilder.Entity("Repository.Models.TblEvent", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("event_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"));

                    b.Property<int?>("AdminId")
                        .HasColumnType("int")
                        .HasColumnName("admin_id");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<string>("EventContent")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("event_content");

                    b.Property<DateTime?>("EventEnd")
                        .HasColumnType("datetime")
                        .HasColumnName("event_end");

                    b.Property<string>("EventName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("event_name");

                    b.Property<DateTime?>("EventStart")
                        .HasColumnType("datetime")
                        .HasColumnName("event_start");

                    b.Property<bool?>("EventStatus")
                        .HasColumnType("bit")
                        .HasColumnName("event_status");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int")
                        .HasColumnName("location_id");

                    b.HasKey("EventId")
                        .HasName("PK__tblEvent__2370F7270519C6AF");

                    b.HasIndex("AdminId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LocationId");

                    b.ToTable("tblEvent", (string)null);
                });

            modelBuilder.Entity("Repository.Models.TblEventParticipated", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("event_id");

                    b.Property<int>("UsersId")
                        .HasColumnType("int")
                        .HasColumnName("users_id");

                    b.Property<DateTime?>("DateParticipated")
                        .HasColumnType("datetime")
                        .HasColumnName("date_participated");

                    b.Property<bool?>("PaymentStatus")
                        .HasColumnType("bit")
                        .HasColumnName("payment_status");

                    b.Property<bool?>("UsersStatus")
                        .HasColumnType("bit")
                        .HasColumnName("users_status");

                    b.HasKey("EventId", "UsersId")
                        .HasName("PK__tblEvent__8DDA8A3308EA5793");

                    b.HasIndex("UsersId");

                    b.ToTable("tblEventParticipated", (string)null);
                });

            modelBuilder.Entity("Repository.Models.TblFeedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("feedback_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackId"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("comment");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("date")
                        .HasColumnName("created_time");

                    b.Property<int?>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("event_id");

                    b.Property<int?>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int")
                        .HasColumnName("users_id");

                    b.HasKey("FeedbackId")
                        .HasName("PK__tblFeedb__7A6B2B8C0CBAE877");

                    b.HasIndex("EventId", "UsersId");

                    b.ToTable("tblFeedback", (string)null);
                });

            modelBuilder.Entity("Repository.Models.TblImage", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("image_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"));

                    b.Property<int?>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("event_id");

                    b.Property<string>("ImageName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("image_name");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image_url");

                    b.HasKey("ImageId")
                        .HasName("PK__tblImage__DC9AC955108B795B");

                    b.HasIndex("EventId");

                    b.ToTable("tblImage", (string)null);
                });

            modelBuilder.Entity("Repository.Models.TblLocation", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("location_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<string>("LocationDetail")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("location_detail");

                    b.Property<string>("LocationStatus")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .HasColumnName("location_status")
                        .IsFixedLength();

                    b.HasKey("LocationId")
                        .HasName("PK__tblLocat__771831EA145C0A3F");

                    b.ToTable("tblLocation", (string)null);
                });

            modelBuilder.Entity("Repository.Models.TblPayment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("payment_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<int?>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("event_id");

                    b.Property<string>("PaymentDetail")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("payment_detail");

                    b.Property<int?>("PaymentFee")
                        .HasColumnType("int")
                        .HasColumnName("payment_fee");

                    b.Property<string>("PaymentUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("payment_url");

                    b.HasKey("PaymentId")
                        .HasName("PK__tblPayme__ED1FC9EA182C9B23");

                    b.HasIndex("EventId");

                    b.ToTable("tblPayment", (string)null);
                });

            modelBuilder.Entity("Repository.Models.TblUser", b =>
                {
                    b.Property<int>("UsersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("users_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsersId"));

                    b.Property<string>("UsersAddress")
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .HasColumnName("users_address")
                        .IsFixedLength();

                    b.Property<string>("UsersEmail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("users_email");

                    b.Property<string>("UsersName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("users_name");

                    b.Property<string>("UsersPhone")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("users_phone")
                        .IsFixedLength();

                    b.HasKey("UsersId")
                        .HasName("PK__tblUser__EAA7D14B1BFD2C07");

                    b.ToTable("tblUser", (string)null);
                });

            modelBuilder.Entity("Repository.Models.TblVideo", b =>
                {
                    b.Property<int>("VideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("video_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VideoId"));

                    b.Property<int?>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("event_id");

                    b.Property<string>("VideoName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("video_name");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("video_url");

                    b.HasKey("VideoId")
                        .HasName("PK__tblVideo__E8F11E1007020F21");

                    b.HasIndex("EventId");

                    b.ToTable("tblVideo", (string)null);
                });

            modelBuilder.Entity("Repository.Models.TblEvent", b =>
                {
                    b.HasOne("Repository.Models.TblAdmin", "Admin")
                        .WithMany("TblEvents")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_tblEvent_tblAdmin");

                    b.HasOne("Repository.Models.TblCategory", "Category")
                        .WithMany("TblEvents")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_tblEvent_tblCategory");

                    b.HasOne("Repository.Models.TblLocation", "Location")
                        .WithMany("TblEvents")
                        .HasForeignKey("LocationId")
                        .HasConstraintName("FK_tblEvent_tblLocation");

                    b.Navigation("Admin");

                    b.Navigation("Category");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Repository.Models.TblEventParticipated", b =>
                {
                    b.HasOne("Repository.Models.TblEvent", "Event")
                        .WithMany("TblEventParticipateds")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_tblEventParticipated_tblEvent");

                    b.HasOne("Repository.Models.TblUser", "Users")
                        .WithMany("TblEventParticipateds")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_tblEventParticipated_tblUser");

                    b.Navigation("Event");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Repository.Models.TblFeedback", b =>
                {
                    b.HasOne("Repository.Models.TblEventParticipated", "TblEventParticipated")
                        .WithMany("TblFeedbacks")
                        .HasForeignKey("EventId", "UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_tblFeedback_tblEventParticipated");

                    b.Navigation("TblEventParticipated");
                });

            modelBuilder.Entity("Repository.Models.TblImage", b =>
                {
                    b.HasOne("Repository.Models.TblEvent", "Event")
                        .WithMany("TblImages")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_tblImage_tblEvent");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Repository.Models.TblPayment", b =>
                {
                    b.HasOne("Repository.Models.TblEvent", "Event")
                        .WithMany("TblPayments")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_tblPayment_tblEvent");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Repository.Models.TblVideo", b =>
                {
                    b.HasOne("Repository.Models.TblEvent", "Event")
                        .WithMany("TblVideos")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_tblVideo_tblEvent");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Repository.Models.TblAdmin", b =>
                {
                    b.Navigation("TblEvents");
                });

            modelBuilder.Entity("Repository.Models.TblCategory", b =>
                {
                    b.Navigation("TblEvents");
                });

            modelBuilder.Entity("Repository.Models.TblEvent", b =>
                {
                    b.Navigation("TblEventParticipateds");

                    b.Navigation("TblImages");

                    b.Navigation("TblPayments");

                    b.Navigation("TblVideos");
                });

            modelBuilder.Entity("Repository.Models.TblEventParticipated", b =>
                {
                    b.Navigation("TblFeedbacks");
                });

            modelBuilder.Entity("Repository.Models.TblLocation", b =>
                {
                    b.Navigation("TblEvents");
                });

            modelBuilder.Entity("Repository.Models.TblUser", b =>
                {
                    b.Navigation("TblEventParticipateds");
                });
#pragma warning restore 612, 618
        }
    }
}