﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using back.Data;

#nullable disable

namespace back.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240616213831_Schedule_change")]
    partial class Schedule_change
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("back.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ModeOfStudy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("back.Models.HomeWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Assignement")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeadLine")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("HomeWorks");
                });

            modelBuilder.Entity("back.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Subject_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GroupId")
                        .IsUnique();

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("back.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("back.Models.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float?>("Grade")
                        .HasColumnType("REAL");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("Speciality")
                        .HasColumnType("TEXT");

                    b.Property<string>("University")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UsersInfos");
                });

            modelBuilder.Entity("back.Models.HomeWork", b =>
                {
                    b.HasOne("back.Models.Group", "Group")
                        .WithMany("HomeWorks")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("back.Models.Schedule", b =>
                {
                    b.HasOne("back.Models.Group", "Group")
                        .WithOne("Schedule")
                        .HasForeignKey("back.Models.Schedule", "GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("back.Models.User", b =>
                {
                    b.HasOne("back.Models.Group", "Group")
                        .WithMany("User")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("back.Models.UserInfo", b =>
                {
                    b.HasOne("back.Models.User", "User")
                        .WithOne("UserInfo")
                        .HasForeignKey("back.Models.UserInfo", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("back.Models.Group", b =>
                {
                    b.Navigation("HomeWorks");

                    b.Navigation("Schedule")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("back.Models.User", b =>
                {
                    b.Navigation("UserInfo")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}