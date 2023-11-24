﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eAgendaMedica.Infra.Orm.Shared;

#nullable disable

namespace eAgendaMedica.Infra.Orm.Migrations
{
    [DbContext(typeof(eAgendaMedicaDbContext))]
    [Migration("20231123175736_Initial-Config")]
    partial class InitialConfig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ActivityDoctor", b =>
                {
                    b.Property<Guid>("ActivitiesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DoctorsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ActivitiesId", "DoctorsId");

                    b.HasIndex("DoctorsId");

                    b.ToTable("TBDoctor_TBActivity", (string)null);
                });

            modelBuilder.Entity("eAgendaMedica.Domain.ActivityModule.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDay")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<DateTime>("StartDay")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TBActivity", (string)null);
                });

            modelBuilder.Entity("eAgendaMedica.Domain.DoctorModule.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TBDoctor", (string)null);
                });

            modelBuilder.Entity("ActivityDoctor", b =>
                {
                    b.HasOne("eAgendaMedica.Domain.ActivityModule.Activity", null)
                        .WithMany()
                        .HasForeignKey("ActivitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eAgendaMedica.Domain.DoctorModule.Doctor", null)
                        .WithMany()
                        .HasForeignKey("DoctorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}