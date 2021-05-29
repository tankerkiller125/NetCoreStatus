﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Staat.Data;

namespace Staat.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Staat.Models.Incident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ServiceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Incident");
                });

            modelBuilder.Entity("Staat.Models.IncidentMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("IncidentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("StatusId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("IncidentId");

                    b.HasIndex("StatusId");

                    b.ToTable("IncidentMessage");
                });

            modelBuilder.Entity("Staat.Models.Monitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CurrentIncidentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastRunTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("MonitorCron")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MonitorTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("NextRunTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Port")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServiceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("ValidateSsl")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CurrentIncidentId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Monitor");
                });

            modelBuilder.Entity("Staat.Models.MonitorData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Available")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("FailureReason")
                        .HasColumnType("TEXT");

                    b.Property<int>("MonitorId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("PingTime")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("SslValid")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MonitorId");

                    b.ToTable("MonitorData");
                });

            modelBuilder.Entity("Staat.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<int?>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<int?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StatusId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("ParentId");

                    b.HasIndex("StatusId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("Staat.Models.ServiceGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("DefaultOpen")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ServiceGroup");
                });

            modelBuilder.Entity("Staat.Models.Settings", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Key");

                    b.HasIndex("Key");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Staat.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Staat.Models.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Staat.Models.Incident", b =>
                {
                    b.HasOne("Staat.Models.Users.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("Staat.Models.Service", "Service")
                        .WithMany("Incidents")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Staat.Models.IncidentMessage", b =>
                {
                    b.HasOne("Staat.Models.Users.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("Staat.Models.Incident", "Incident")
                        .WithMany("Messages")
                        .HasForeignKey("IncidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Staat.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Author");

                    b.Navigation("Incident");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Staat.Models.Monitor", b =>
                {
                    b.HasOne("Staat.Models.Incident", "CurrentIncident")
                        .WithMany()
                        .HasForeignKey("CurrentIncidentId");

                    b.HasOne("Staat.Models.Service", "Service")
                        .WithMany("Monitors")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentIncident");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Staat.Models.MonitorData", b =>
                {
                    b.HasOne("Staat.Models.Monitor", "Monitor")
                        .WithMany("Data")
                        .HasForeignKey("MonitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monitor");
                });

            modelBuilder.Entity("Staat.Models.Service", b =>
                {
                    b.HasOne("Staat.Models.ServiceGroup", "Group")
                        .WithMany("Services")
                        .HasForeignKey("GroupId");

                    b.HasOne("Staat.Models.Service", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.HasOne("Staat.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Group");

                    b.Navigation("Parent");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Staat.Models.Incident", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Staat.Models.Monitor", b =>
                {
                    b.Navigation("Data");
                });

            modelBuilder.Entity("Staat.Models.Service", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Incidents");

                    b.Navigation("Monitors");
                });

            modelBuilder.Entity("Staat.Models.ServiceGroup", b =>
                {
                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}
