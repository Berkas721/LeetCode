﻿// <auto-generated />
using System;
using LeetCode.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LeetCode.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241113001919_RemovedUselessPropertiesInLanguage")]
    partial class RemovedUselessPropertiesInLanguage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("leetcode")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

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

                    b.ToTable("AspNetUsers", "leetcode");
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

                    b.ToTable("AspNetRoles", "leetcode");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.ImplementedProblem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProblemCode")
                        .IsRequired()
                        .HasMaxLength(4096)
                        .HasColumnType("character varying(4096)");

                    b.Property<long>("ProblemId")
                        .HasColumnType("bigint");

                    b.Property<string>("WorkingSolutionCode")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.HasKey("Id");

                    b.HasAlternateKey("ProblemId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("ImplementedProblems", "leetcode");
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Problems", "leetcode");
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

                    b.Property<long[]>("FailedTestIds")
                        .HasColumnType("bigint[]");

                    b.Property<Guid>("ImplementedProblemId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("SubmittedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("TotalUsedMemory")
                        .HasColumnType("bigint");

                    b.Property<long?>("TotalUsedTime")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ImplementedProblemId");

                    b.ToTable("ProblemSolutions", "leetcode");
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

                    b.ToTable("ProblemTopics", "leetcode");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.ProgrammingLanguage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageName")
                        .IsUnique();

                    b.ToTable("Languages", "leetcode");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.SolutionTest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ErrorMessage")
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<string>("IncorrectAnswer")
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<int>("ResultStatus")
                        .HasColumnType("integer");

                    b.Property<long>("SolutionId")
                        .HasColumnType("bigint");

                    b.Property<long>("TestCaseId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UsedMemory")
                        .HasColumnType("bigint");

                    b.Property<long?>("UsedTime")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasAlternateKey("SolutionId", "TestCaseId");

                    b.HasIndex("TestCaseId");

                    b.ToTable("SolutionTests", "leetcode");
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

                    b.HasIndex("ProblemId", "Input")
                        .IsUnique();

                    b.ToTable("TestCases", "leetcode");
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

                    b.ToTable("AspNetRoleClaims", "leetcode");
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

                    b.ToTable("AspNetUserClaims", "leetcode");
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

                    b.ToTable("AspNetUserLogins", "leetcode");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", "leetcode");
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

                    b.ToTable("AspNetUserTokens", "leetcode");
                });

            modelBuilder.Entity("ProblemProblemTopic", b =>
                {
                    b.Property<long>("ProblemsId")
                        .HasColumnType("bigint");

                    b.Property<long>("TopicsId")
                        .HasColumnType("bigint");

                    b.HasKey("ProblemsId", "TopicsId");

                    b.HasIndex("TopicsId");

                    b.ToTable("ProblemProblemTopic", "leetcode");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.ImplementedProblem", b =>
                {
                    b.HasOne("LeetCode.Data.Entities.ProgrammingLanguage", "Language")
                        .WithMany("ImplementedProblems")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeetCode.Data.Entities.Problem", "Problem")
                        .WithMany("ImplementedProblems")
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("LeetCode.Data.OwnedTypes.ActionInfo", "CreateInfo", b1 =>
                        {
                            b1.Property<Guid>("ImplementedProblemId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("AgentId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("ImplementedProblemId");

                            b1.HasIndex("AgentId");

                            b1.ToTable("ImplementedProblems", "leetcode");

                            b1.HasOne("LeetCode.Data.Entities.ApplicationUser", "Agent")
                                .WithMany()
                                .HasForeignKey("AgentId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("ImplementedProblemId");

                            b1.Navigation("Agent");
                        });

                    b.OwnsOne("LeetCode.Data.OwnedTypes.ActionInfo", "DeleteInfo", b1 =>
                        {
                            b1.Property<Guid>("ImplementedProblemId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("AgentId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("ImplementedProblemId");

                            b1.HasIndex("AgentId");

                            b1.ToTable("ImplementedProblems", "leetcode");

                            b1.HasOne("LeetCode.Data.Entities.ApplicationUser", "Agent")
                                .WithMany()
                                .HasForeignKey("AgentId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("ImplementedProblemId");

                            b1.Navigation("Agent");
                        });

                    b.Navigation("CreateInfo")
                        .IsRequired();

                    b.Navigation("DeleteInfo");

                    b.Navigation("Language");

                    b.Navigation("Problem");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.Problem", b =>
                {
                    b.OwnsOne("LeetCode.Data.OwnedTypes.ActionInfo", "CreateInfo", b1 =>
                        {
                            b1.Property<long>("ProblemId")
                                .HasColumnType("bigint");

                            b1.Property<Guid>("AgentId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("ProblemId");

                            b1.HasIndex("AgentId");

                            b1.ToTable("Problems", "leetcode");

                            b1.HasOne("LeetCode.Data.Entities.ApplicationUser", "Agent")
                                .WithMany()
                                .HasForeignKey("AgentId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("ProblemId");

                            b1.Navigation("Agent");
                        });

                    b.OwnsOne("LeetCode.Data.OwnedTypes.ActionInfo", "DeleteInfo", b1 =>
                        {
                            b1.Property<long>("ProblemId")
                                .HasColumnType("bigint");

                            b1.Property<Guid>("AgentId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("ProblemId");

                            b1.HasIndex("AgentId");

                            b1.ToTable("Problems", "leetcode");

                            b1.HasOne("LeetCode.Data.Entities.ApplicationUser", "Agent")
                                .WithMany()
                                .HasForeignKey("AgentId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("ProblemId");

                            b1.Navigation("Agent");
                        });

                    b.OwnsOne("LeetCode.Data.OwnedTypes.ActionInfo", "OpenInfo", b1 =>
                        {
                            b1.Property<long>("ProblemId")
                                .HasColumnType("bigint");

                            b1.Property<Guid>("AgentId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("ProblemId");

                            b1.HasIndex("AgentId");

                            b1.ToTable("Problems", "leetcode");

                            b1.HasOne("LeetCode.Data.Entities.ApplicationUser", "Agent")
                                .WithMany()
                                .HasForeignKey("AgentId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("ProblemId");

                            b1.Navigation("Agent");
                        });

                    b.OwnsOne("LeetCode.Data.OwnedTypes.ActionInfo", "UpdateInfo", b1 =>
                        {
                            b1.Property<long>("ProblemId")
                                .HasColumnType("bigint");

                            b1.Property<Guid>("AgentId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("ProblemId");

                            b1.HasIndex("AgentId");

                            b1.ToTable("Problems", "leetcode");

                            b1.HasOne("LeetCode.Data.Entities.ApplicationUser", "Agent")
                                .WithMany()
                                .HasForeignKey("AgentId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("ProblemId");

                            b1.Navigation("Agent");
                        });

                    b.Navigation("CreateInfo")
                        .IsRequired();

                    b.Navigation("DeleteInfo");

                    b.Navigation("OpenInfo");

                    b.Navigation("UpdateInfo");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.ProblemSolution", b =>
                {
                    b.HasOne("LeetCode.Data.Entities.ImplementedProblem", "ImplementedProblem")
                        .WithMany("Solutions")
                        .HasForeignKey("ImplementedProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImplementedProblem");
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

                    b.OwnsOne("LeetCode.Data.OwnedTypes.ActionInfo", "CreateInfo", b1 =>
                        {
                            b1.Property<long>("TestCaseId")
                                .HasColumnType("bigint");

                            b1.Property<Guid>("AgentId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("TestCaseId");

                            b1.HasIndex("AgentId");

                            b1.ToTable("TestCases", "leetcode");

                            b1.HasOne("LeetCode.Data.Entities.ApplicationUser", "Agent")
                                .WithMany()
                                .HasForeignKey("AgentId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("TestCaseId");

                            b1.Navigation("Agent");
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

            modelBuilder.Entity("LeetCode.Data.Entities.ImplementedProblem", b =>
                {
                    b.Navigation("Solutions");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.Problem", b =>
                {
                    b.Navigation("ImplementedProblems");

                    b.Navigation("TestCases");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.ProblemSolution", b =>
                {
                    b.Navigation("Tests");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.ProgrammingLanguage", b =>
                {
                    b.Navigation("ImplementedProblems");
                });

            modelBuilder.Entity("LeetCode.Data.Entities.TestCase", b =>
                {
                    b.Navigation("SolutionTests");
                });
#pragma warning restore 612, 618
        }
    }
}
