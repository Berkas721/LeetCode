﻿// <auto-generated />
using System;
using System.Collections.Generic;
using LeetCode.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LeetCode.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "hstore");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LeetCode.Data.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

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

                    b.Property<DateOnly>("Registration")
                        .HasColumnType("date");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("LeetCode.Data.Entities.ApplicationUserRole", b =>
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

            modelBuilder.Entity("LeetCode.Data.Entities.Problem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<int>("Difficulty")
                        .HasColumnType("integer");

                    b.Property<bool>("IsPremiumRequired")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<DateTime?>("OpenAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Problems");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.ProblemResolveSession", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ProblemId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasAlternateKey("UserId", "ProblemId");

                    b.HasIndex("ProblemId");

                    b.ToTable("ProblemResolveSessions");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.ProblemSolution", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(4096)
                        .HasColumnType("character varying(4096)");

                    b.Property<string>("Notes")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<Guid>("RunningDetailsId")
                        .HasColumnType("uuid");

                    b.Property<long>("SessionId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RunningDetailsId");

                    b.HasIndex("SessionId");

                    b.ToTable("ProblemSolutions");

                    b.HasDiscriminator<int>("Status").HasValue(0);

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("LeetCode.Data.Entities.ProblemTopic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ProblemTopics");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.ProgrammingLanguage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.ProgrammingLanguageWithVersion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Dictionary<string, string>>("AdditionalDetails")
                        .IsRequired()
                        .HasColumnType("hstore");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<long?>("ProgrammingLanguageId")
                        .HasColumnType("bigint");

                    b.Property<DateOnly>("RealizedAt")
                        .HasColumnType("date");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name", "Version");

                    b.HasIndex("ProgrammingLanguageId");

                    b.ToTable("LanguagesWithVersion");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.SolutionRunningDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Dictionary<string, string>>("AdditionalDetails")
                        .IsRequired()
                        .HasColumnType("hstore");

                    b.Property<string>("DefaultCode")
                        .IsRequired()
                        .HasMaxLength(4096)
                        .HasColumnType("character varying(4096)");

                    b.Property<long>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProblemId")
                        .HasColumnType("bigint");

                    b.Property<string>("WorkingSolution")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.HasKey("Id");

                    b.HasAlternateKey("ProblemId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("SolutionsRunningDetails");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.SolutionTest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ResultStatus")
                        .HasColumnType("integer");

                    b.Property<long>("SolutionId")
                        .HasColumnType("bigint");

                    b.Property<long>("TestCaseId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasAlternateKey("SolutionId", "TestCaseId");

                    b.HasIndex("TestCaseId");

                    b.ToTable("SolutionTests");

                    b.HasDiscriminator<int>("ResultStatus").HasValue(0);

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("LeetCode.Data.Entities.TestCase", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Input")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<string>("Output")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<long>("ProblemId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasAlternateKey("ProblemId", "Input");

                    b.ToTable("TestCases");
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

            modelBuilder.Entity("ProblemProblemTopic", b =>
                {
                    b.Property<long>("ProblemsId")
                        .HasColumnType("bigint");

                    b.Property<long>("TopicsId")
                        .HasColumnType("bigint");

                    b.HasKey("ProblemsId", "TopicsId");

                    b.HasIndex("TopicsId");

                    b.ToTable("ProblemProblemTopic");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.AcceptedSolution", b =>
                {
                    b.HasBaseType("LeetCode.Data.Entities.ProblemSolution");

                    b.Property<DateTime>("SubmittedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("SubmittedAt");

                    b.Property<int>("TotalUsedMemory")
                        .HasColumnType("integer");

                    b.Property<int>("TotalUsedTime")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("LeetCode.Data.Entities.DraftSolution", b =>
                {
                    b.HasBaseType("LeetCode.Data.Entities.ProblemSolution");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("LeetCode.Data.Entities.UnAcceptedSolution", b =>
                {
                    b.HasBaseType("LeetCode.Data.Entities.ProblemSolution");

                    b.Property<DateTime>("SubmittedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("SubmittedAt");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("LeetCode.Data.Entities.FailedWithErrorTest", b =>
                {
                    b.HasBaseType("LeetCode.Data.Entities.SolutionTest");

                    b.Property<string>("ErrorMessage")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<int>("ErrorType")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("LeetCode.Data.Entities.FailedWithIncorrectAnswerTest", b =>
                {
                    b.HasBaseType("LeetCode.Data.Entities.SolutionTest");

                    b.Property<string>("IncorrectAnswer")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("LeetCode.Data.Entities.PassedTest", b =>
                {
                    b.HasBaseType("LeetCode.Data.Entities.SolutionTest");

                    b.Property<int>("UsedMemory")
                        .HasColumnType("integer");

                    b.Property<int>("UsedTime")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("LeetCode.Data.Entities.Problem", b =>
                {
                    b.OwnsOne("LeetCode.Data.OwnedTypes.CreateInfo", "CreateInfo", b1 =>
                        {
                            b1.Property<long>("ProblemId")
                                .HasColumnType("bigint");

                            b1.Property<Guid>("CreatorId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("ProblemId");

                            b1.HasIndex("CreatorId");

                            b1.ToTable("Problems");

                            b1.HasOne("LeetCode.Data.Entities.ApplicationUser", "Creator")
                                .WithMany()
                                .HasForeignKey("CreatorId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("ProblemId");

                            b1.Navigation("Creator");
                        });

                    b.OwnsOne("LeetCode.Data.OwnedTypes.DeleteInfo", "DeleteInfo", b1 =>
                        {
                            b1.Property<long>("ProblemId")
                                .HasColumnType("bigint");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<Guid>("DeleterId")
                                .HasColumnType("uuid");

                            b1.HasKey("ProblemId");

                            b1.HasIndex("DeleterId");

                            b1.ToTable("Problems");

                            b1.HasOne("LeetCode.Data.Entities.ApplicationUser", "Deleter")
                                .WithMany()
                                .HasForeignKey("DeleterId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("ProblemId");

                            b1.Navigation("Deleter");
                        });

                    b.OwnsOne("LeetCode.Data.OwnedTypes.UpdateInfo", "UpdateInfo", b1 =>
                        {
                            b1.Property<long>("ProblemId")
                                .HasColumnType("bigint");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<Guid>("UpdaterId")
                                .HasColumnType("uuid");

                            b1.HasKey("ProblemId");

                            b1.HasIndex("UpdaterId");

                            b1.ToTable("Problems");

                            b1.WithOwner()
                                .HasForeignKey("ProblemId");

                            b1.HasOne("LeetCode.Data.Entities.ApplicationUser", "Updater")
                                .WithMany()
                                .HasForeignKey("UpdaterId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.Navigation("Updater");
                        });

                    b.Navigation("CreateInfo")
                        .IsRequired();

                    b.Navigation("DeleteInfo");

                    b.Navigation("UpdateInfo");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.ProblemResolveSession", b =>
                {
                    b.HasOne("LeetCode.Data.Entities.Problem", "Problem")
                        .WithMany("ResolveSessions")
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeetCode.Data.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Problem");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.ProblemSolution", b =>
                {
                    b.HasOne("LeetCode.Data.Entities.SolutionRunningDetails", "RunningDetails")
                        .WithMany("Solutions")
                        .HasForeignKey("RunningDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeetCode.Data.Entities.ProblemResolveSession", "Session")
                        .WithMany("Solutions")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RunningDetails");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.ProgrammingLanguageWithVersion", b =>
                {
                    b.HasOne("LeetCode.Data.Entities.ProgrammingLanguage", "Language")
                        .WithMany()
                        .HasForeignKey("Name")
                        .HasPrincipalKey("Name")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeetCode.Data.Entities.ProgrammingLanguage", null)
                        .WithMany("Versions")
                        .HasForeignKey("ProgrammingLanguageId");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.SolutionRunningDetails", b =>
                {
                    b.HasOne("LeetCode.Data.Entities.ProgrammingLanguageWithVersion", "Language")
                        .WithMany("SolutionRunningDetails")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeetCode.Data.Entities.Problem", "Problem")
                        .WithMany("SolutionRunningDetails")
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("LeetCode.Data.OwnedTypes.CreateInfo", "CreateInfo", b1 =>
                        {
                            b1.Property<Guid>("SolutionRunningDetailsId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("CreatorId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("SolutionRunningDetailsId");

                            b1.HasIndex("CreatorId");

                            b1.ToTable("SolutionsRunningDetails");

                            b1.HasOne("LeetCode.Data.Entities.ApplicationUser", "Creator")
                                .WithMany()
                                .HasForeignKey("CreatorId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("SolutionRunningDetailsId");

                            b1.Navigation("Creator");
                        });

                    b.OwnsOne("LeetCode.Data.OwnedTypes.DeleteInfo", "DeleteInfo", b1 =>
                        {
                            b1.Property<Guid>("SolutionRunningDetailsId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<Guid>("DeleterId")
                                .HasColumnType("uuid");

                            b1.HasKey("SolutionRunningDetailsId");

                            b1.HasIndex("DeleterId");

                            b1.ToTable("SolutionsRunningDetails");

                            b1.HasOne("LeetCode.Data.Entities.ApplicationUser", "Deleter")
                                .WithMany()
                                .HasForeignKey("DeleterId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("SolutionRunningDetailsId");

                            b1.Navigation("Deleter");
                        });

                    b.Navigation("CreateInfo")
                        .IsRequired();

                    b.Navigation("DeleteInfo");

                    b.Navigation("Language");

                    b.Navigation("Problem");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.SolutionTest", b =>
                {
                    b.HasOne("LeetCode.Data.Entities.ProblemSolution", "Solution")
                        .WithMany("Tests")
                        .HasForeignKey("SolutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeetCode.Data.Entities.TestCase", "TestCase")
                        .WithMany("SolutionTests")
                        .HasForeignKey("TestCaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Solution");

                    b.Navigation("TestCase");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.TestCase", b =>
                {
                    b.HasOne("LeetCode.Data.Entities.Problem", "Problem")
                        .WithMany("TestCases")
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("LeetCode.Data.OwnedTypes.CreateInfo", "CreateInfo", b1 =>
                        {
                            b1.Property<long>("TestCaseId")
                                .HasColumnType("bigint");

                            b1.Property<Guid>("CreatorId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("TestCaseId");

                            b1.HasIndex("CreatorId");

                            b1.ToTable("TestCases");

                            b1.HasOne("LeetCode.Data.Entities.ApplicationUser", "Creator")
                                .WithMany()
                                .HasForeignKey("CreatorId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("TestCaseId");

                            b1.Navigation("Creator");
                        });

                    b.Navigation("CreateInfo")
                        .IsRequired();

                    b.Navigation("Problem");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("LeetCode.Data.Entities.ApplicationUserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("LeetCode.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("LeetCode.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("LeetCode.Data.Entities.ApplicationUserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeetCode.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("LeetCode.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProblemProblemTopic", b =>
                {
                    b.HasOne("LeetCode.Data.Entities.Problem", null)
                        .WithMany()
                        .HasForeignKey("ProblemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeetCode.Data.Entities.ProblemTopic", null)
                        .WithMany()
                        .HasForeignKey("TopicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LeetCode.Data.Entities.Problem", b =>
                {
                    b.Navigation("ResolveSessions");

                    b.Navigation("SolutionRunningDetails");

                    b.Navigation("TestCases");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.ProblemResolveSession", b =>
                {
                    b.Navigation("Solutions");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.ProblemSolution", b =>
                {
                    b.Navigation("Tests");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.ProgrammingLanguage", b =>
                {
                    b.Navigation("Versions");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.ProgrammingLanguageWithVersion", b =>
                {
                    b.Navigation("SolutionRunningDetails");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.SolutionRunningDetails", b =>
                {
                    b.Navigation("Solutions");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.TestCase", b =>
                {
                    b.Navigation("SolutionTests");
                });
#pragma warning restore 612, 618
        }
    }
}
