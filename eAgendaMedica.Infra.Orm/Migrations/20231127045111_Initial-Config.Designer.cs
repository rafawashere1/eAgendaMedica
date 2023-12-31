﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using eAgendaMedica.Infra.Orm.Shared;

#nullable disable

namespace eAgendaMedica.Infra.Orm.Migrations
{
    [DbContext(typeof(eAgendaMedicaDbContext))]
    [Migration("20231127045111_Initial-Config")]
    partial class InitialConfig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("eAgendaMedica.Domain.ActivityModule.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndDay")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("interval");

                    b.Property<DateTime>("StartDay")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("interval");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TBActivity", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("aeafd397-2b6a-4e52-8f1f-fb62a1e69cf3"),
                            EndDay = new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 10, 30, 0, 0),
                            StartDay = new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new TimeSpan(0, 10, 0, 0, 0),
                            Theme = "primary",
                            Title = "Consulta Geral",
                            Type = 1,
                            UserId = new Guid("e7944276-5214-46c7-2755-08dbede3db7d")
                        },
                        new
                        {
                            Id = new Guid("7130c4c9-1dd8-4bea-94d0-44520e2b5278"),
                            EndDay = new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 11, 30, 0, 0),
                            StartDay = new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new TimeSpan(0, 11, 0, 0, 0),
                            Theme = "primary",
                            Title = "Checkup",
                            Type = 1,
                            UserId = new Guid("e7944276-5214-46c7-2755-08dbede3db7d")
                        },
                        new
                        {
                            Id = new Guid("c0d74dd3-b8e3-4115-b9be-b4d900e9c990"),
                            EndDay = new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 12, 30, 0, 0),
                            StartDay = new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new TimeSpan(0, 12, 0, 0, 0),
                            Theme = "primary",
                            Title = "Exame de Sangue",
                            Type = 1,
                            UserId = new Guid("e7944276-5214-46c7-2755-08dbede3db7d")
                        },
                        new
                        {
                            Id = new Guid("4df543cc-85e1-4bd8-bd11-0af445c5e61f"),
                            EndDay = new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 11, 30, 0, 0),
                            StartDay = new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new TimeSpan(0, 11, 0, 0, 0),
                            Theme = "accent",
                            Title = "Cirurgia Cardíaca",
                            Type = 0,
                            UserId = new Guid("e7944276-5214-46c7-2755-08dbede3db7d")
                        },
                        new
                        {
                            Id = new Guid("fc2a6804-5a14-4754-99c9-4d6f878f9ed1"),
                            EndDay = new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 11, 30, 0, 0),
                            StartDay = new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new TimeSpan(0, 11, 0, 0, 0),
                            Theme = "warn",
                            Title = "Cirurgia de Emergência",
                            Type = 0,
                            UserId = new Guid("e7944276-5214-46c7-2755-08dbede3db7d")
                        });
                });

            modelBuilder.Entity("eAgendaMedica.Domain.AuthModule.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("e7944276-5214-46c7-2755-08dbede3db7d"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6f07bdcf-9ff3-43da-9f8b-5e27808f81ab",
                            Email = "teste@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            Name = "Teste",
                            NormalizedEmail = "TESTE@GMAIL.COM",
                            NormalizedUserName = "TESTE@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEEpbfL1sGZGAQmfY11et9nzZ5tdMmLv5uVMiv4xXugJLxfksPyB7aJgai6Yym57vFQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "NQY5DMARMJNDQ7CUQJP3U4O7SYXLNANC",
                            TwoFactorEnabled = false,
                            UserName = "teste@gmail.com"
                        });
                });

            modelBuilder.Entity("eAgendaMedica.Domain.DoctorModule.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TBDoctor", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("6f095f41-5503-42a2-8412-8d2bb95c0042"),
                            CRM = "04474-RS",
                            Name = "Rafael",
                            UserId = new Guid("e7944276-5214-46c7-2755-08dbede3db7d")
                        },
                        new
                        {
                            Id = new Guid("1cc3bb32-627c-4e79-9f4a-3fbff06bbbdf"),
                            CRM = "23456-SC",
                            Name = "João",
                            UserId = new Guid("e7944276-5214-46c7-2755-08dbede3db7d")
                        },
                        new
                        {
                            Id = new Guid("6275b95e-03e9-4213-9303-f0745608f706"),
                            CRM = "82460-SC",
                            Name = "Rech",
                            UserId = new Guid("e7944276-5214-46c7-2755-08dbede3db7d")
                        },
                        new
                        {
                            Id = new Guid("c20e745a-da4c-4f8f-9f8f-7d5c74cafb6f"),
                            CRM = "61458-SC",
                            Name = "Tiago",
                            UserId = new Guid("e7944276-5214-46c7-2755-08dbede3db7d")
                        },
                        new
                        {
                            Id = new Guid("ad42d17f-9f8d-4f5b-983e-6ad44906b347"),
                            CRM = "02457-SP",
                            Name = "Matheus",
                            UserId = new Guid("e7944276-5214-46c7-2755-08dbede3db7d")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TBDoctor_TBActivity", b =>
                {
                    b.Property<Guid>("ActivityId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uuid");

                    b.HasKey("ActivityId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("TBDoctor_TBActivity");

                    b.HasData(
                        new
                        {
                            ActivityId = new Guid("aeafd397-2b6a-4e52-8f1f-fb62a1e69cf3"),
                            DoctorId = new Guid("6f095f41-5503-42a2-8412-8d2bb95c0042")
                        },
                        new
                        {
                            ActivityId = new Guid("7130c4c9-1dd8-4bea-94d0-44520e2b5278"),
                            DoctorId = new Guid("1cc3bb32-627c-4e79-9f4a-3fbff06bbbdf")
                        },
                        new
                        {
                            ActivityId = new Guid("c0d74dd3-b8e3-4115-b9be-b4d900e9c990"),
                            DoctorId = new Guid("6275b95e-03e9-4213-9303-f0745608f706")
                        },
                        new
                        {
                            ActivityId = new Guid("4df543cc-85e1-4bd8-bd11-0af445c5e61f"),
                            DoctorId = new Guid("c20e745a-da4c-4f8f-9f8f-7d5c74cafb6f")
                        },
                        new
                        {
                            ActivityId = new Guid("fc2a6804-5a14-4754-99c9-4d6f878f9ed1"),
                            DoctorId = new Guid("ad42d17f-9f8d-4f5b-983e-6ad44906b347")
                        });
                });

            modelBuilder.Entity("eAgendaMedica.Domain.ActivityModule.Activity", b =>
                {
                    b.HasOne("eAgendaMedica.Domain.AuthModule.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("eAgendaMedica.Domain.DoctorModule.Doctor", b =>
                {
                    b.HasOne("eAgendaMedica.Domain.AuthModule.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("eAgendaMedica.Domain.AuthModule.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("eAgendaMedica.Domain.AuthModule.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eAgendaMedica.Domain.AuthModule.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("eAgendaMedica.Domain.AuthModule.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TBDoctor_TBActivity", b =>
                {
                    b.HasOne("eAgendaMedica.Domain.ActivityModule.Activity", null)
                        .WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eAgendaMedica.Domain.DoctorModule.Doctor", null)
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
